using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using _3D_Printing_Service.Data;
using _3D_Printing_Service.Models;
using _3D_Printing_Service.Models.ViewModels;
using _3D_Printing_Service.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace _3D_Printing_Service.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public OrderDetailsCart detailCart { get; set; }

        public CartController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET Index
        public async Task<IActionResult> Index()
        {
            detailCart = new OrderDetailsCart()
            {
                OrderHeader = new Models.OrderHeader()
            };

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var cart = _db.ShoppingCart.Where(c => c.ApplicationUserId == claim.Value);

            if(cart!=null)
            {
                detailCart.listCart = cart.ToList();
            }

            foreach(var list in detailCart.listCart)
            {
                list.Product = await _db.Product.FirstOrDefaultAsync(m => m.Id == list.ProductId);
                detailCart.OrderHeader.OrderTotal = detailCart.OrderHeader.OrderTotal + (list.Product.Price * list.Count);
                if(list.Product.Description.Length > 100)
                {
                    list.Product.Description = list.Product.Description.Substring(0, 99) + "...";
                }
            }
            detailCart.OrderHeader.OrderTotalOriginal = detailCart.OrderHeader.OrderTotal;

            if(HttpContext.Session.GetString(SD.ssDiscountCode) != null)
            {
                detailCart.OrderHeader.DiscountCode = HttpContext.Session.GetString(SD.ssDiscountCode);
                var discountFromDb = await _db.Discount.Where(c => c.Name.ToLower() == detailCart.OrderHeader.DiscountCode.ToLower()).FirstOrDefaultAsync();
                detailCart.OrderHeader.OrderTotal = SD.DiscountedPrice(discountFromDb, detailCart.OrderHeader.OrderTotalOriginal);
            }

            return View(detailCart);
        }

        public async Task<IActionResult> Summary()
        {
            detailCart = new OrderDetailsCart()
            {
                OrderHeader = new Models.OrderHeader()
            };
            detailCart.OrderHeader.OrderTotal = 0;
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            ApplicationUser applicationUser = await _db.ApplicationUser.Where(c => c.Id == claim.Value).FirstOrDefaultAsync();

            var cart = _db.ShoppingCart.Where(c => c.ApplicationUserId == claim.Value);

            if(cart!=null)
            {
                detailCart.listCart = cart.ToList();
            }

            foreach(var list in detailCart.listCart)
            {
                list.Product = await _db.Product.FirstOrDefaultAsync(m => m.Id == list.ProductId);
                detailCart.OrderHeader.OrderTotal = detailCart.OrderHeader.OrderTotal + (list.Product.Price * list.Count);
            }

            detailCart.OrderHeader.OrderTotalOriginal = detailCart.OrderHeader.OrderTotal;

            detailCart.OrderHeader.PickupName = applicationUser.FirstName;
            detailCart.OrderHeader.PhoneNumber = applicationUser.PhoneNumber;
            //detailCart.OrderHeader.PickUpTime = DateTime.Now;

            if(HttpContext.Session.GetString(SD.ssDiscountCode) != null)
            {
                detailCart.OrderHeader.DiscountCode = HttpContext.Session.GetString(SD.ssDiscountCode);
                var discountFromDb = await _db.Discount.Where(c => c.Name.ToLower() == detailCart.OrderHeader.DiscountCode.ToLower()).FirstOrDefaultAsync();
                detailCart.OrderHeader.OrderTotal = SD.DiscountedPrice(discountFromDb, detailCart.OrderHeader.OrderTotalOriginal);
            }

            return View(detailCart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Summary")]
        public async Task<IActionResult> SummaryPost(string stripeToken)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            detailCart.listCart = await _db.ShoppingCart.Where(c => c.ApplicationUserId == claim.Value).ToListAsync();

            detailCart.OrderHeader.PaymentStatus = SD.PaymentStatusPending;
            detailCart.OrderHeader.OrderDate = DateTime.Now;
            detailCart.OrderHeader.UserId = claim.Value;
            detailCart.OrderHeader.Status = SD.PaymentStatusPending;
            //detailCart.OrderHeader.PickUpTime = Convert.ToDateTime(detailCart.OrderHeader.PickUpDate.ToShortDateString)() + " " + detailCart.OrderHeader.PickUpTime.ToShortTimeString());

            List<OrderDetails> orderDetailsList = new List<OrderDetails>();
            _db.OrderHeader.Add(detailCart.OrderHeader);
            await _db.SaveChangesAsync();

            detailCart.OrderHeader.OrderTotalOriginal = 0;

            foreach(var item in detailCart.listCart)
            {
                item.Product = await _db.Product.FirstOrDefaultAsync(m => m.Id == item.ProductId);
                OrderDetails orderDetails = new OrderDetails
                {
                    ProductId = item.ProductId,
                    OrderId = detailCart.OrderHeader.Id,
                    Description = item.Product.Description,
                    Name = item.Product.Name,
                    Price = item.Product.Price,
                    Count = item.Count
                };
                detailCart.OrderHeader.OrderTotalOriginal += orderDetails.Count * orderDetails.Price;
                _db.OrderDetails.Add(orderDetails);
            }
            if(HttpContext.Session.GetString(SD.ssDiscountCode) != null)
            {
                detailCart.OrderHeader.DiscountCode = HttpContext.Session.GetString(SD.ssDiscountCode);
                var discountFromDb = await _db.Discount.Where(c => c.Name.ToLower() == detailCart.OrderHeader.DiscountCode.ToLower()).FirstOrDefaultAsync();
                detailCart.OrderHeader.OrderTotal = SD.DiscountedPrice(discountFromDb, detailCart.OrderHeader.OrderTotalOriginal);
            }
            else
            {
                detailCart.OrderHeader.OrderTotal = detailCart.OrderHeader.OrderTotalOriginal;
            }
            detailCart.OrderHeader.DiscountCodeDiscount = detailCart.OrderHeader.OrderTotalOriginal - detailCart.OrderHeader.OrderTotal;

            _db.ShoppingCart.RemoveRange(detailCart.listCart);
            HttpContext.Session.SetInt32(SD.ssShoppingCartCount, 0);
            await _db.SaveChangesAsync();

            var options = new ChargeCreateOptions
            {
                Amount = Convert.ToInt32(detailCart.OrderHeader.OrderTotal * 100),
                Currency = "usd",
                Description = "Order ID : " + detailCart.OrderHeader.Id,
                Source = stripeToken
            };
            var service = new ChargeService();
            Charge charge = service.Create(options);

            if(charge.BalanceTransactionId == null)
            {
                detailCart.OrderHeader.PaymentStatus = SD.PaymentStatusRejected;
            }
            else
            {
                detailCart.OrderHeader.TransactionId = charge.BalanceTransactionId;
            }

            if(charge.Status.ToLower() == "succeeded")
            {
                detailCart.OrderHeader.PaymentStatus = SD.PaymentStatusApproved;
                detailCart.OrderHeader.Status = SD.StatusSubmitted;
            }
            else
            {
                detailCart.OrderHeader.PaymentStatus = SD.PaymentStatusRejected;
            }

            await _db.SaveChangesAsync();

            return RedirectToAction("Confirm", "Order", new { id = detailCart.OrderHeader.Id });

        }

        public IActionResult AddDiscount()
        {
            if(detailCart.OrderHeader.DiscountCode == null)
            {
                detailCart.OrderHeader.DiscountCode = "";
            }
            HttpContext.Session.SetString(SD.ssDiscountCode, detailCart.OrderHeader.DiscountCode);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveDiscount()
        {
            HttpContext.Session.SetString(SD.ssDiscountCode, string.Empty);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Plus(int cartId)
        {
            var cart = await _db.ShoppingCart.FirstOrDefaultAsync(c => c.Id == cartId);
            cart.Count += 1;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Minus(int cartId)
        {
            var cart = await _db.ShoppingCart.FirstOrDefaultAsync(c => c.Id == cartId);

            if(cart.Count==1)
            {
                _db.ShoppingCart.Remove(cart);
                await _db.SaveChangesAsync();
                var cnt = _db.ShoppingCart.Where(u => u.ApplicationUserId == cart.ApplicationUserId).ToList().Count;
                HttpContext.Session.SetInt32(SD.ssShoppingCartCount, cnt);
            }
            else
            {
                cart.Count -= 1;
                await _db.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Remove(int cartId)
        {
            var cart = await _db.ShoppingCart.FirstOrDefaultAsync(c => c.Id == cartId);
            _db.ShoppingCart.Remove(cart);
            await _db.SaveChangesAsync();

            var cnt = _db.ShoppingCart.Where(u => u.ApplicationUserId == cart.ApplicationUserId).ToList().Count;
            HttpContext.Session.SetInt32(SD.ssShoppingCartCount, cnt);

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}