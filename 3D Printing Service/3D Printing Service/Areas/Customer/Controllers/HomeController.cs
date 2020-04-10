using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _3D_Printing_Service.Models;
using _3D_Printing_Service.Data;
using _3D_Printing_Service.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using _3D_Printing_Service.Utility;
using Microsoft.AspNetCore.Http;

namespace _3D_Printing_Service.Controllers
{
	[Area("Customer")]
	public class HomeController : Controller
	{

		private readonly ApplicationDbContext _db;

		public HomeController(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task<IActionResult> Index()
		{
			IndexViewModel IndexVM = new IndexViewModel()
			{
				Product = await _db.Product.Include(m => m.Category).Include(m => m.SubCategory).ToListAsync(),
				Category = await _db.Category.ToListAsync(),
				Discount = await _db.Discount.Where(c=>c.isActive==true).ToListAsync()
			};

			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

			if(claim!=null)
			{
				var cnt = _db.ShoppingCart.Where(u => u.ApplicationUserId == claim.Value).ToList().Count;
				HttpContext.Session.SetInt32(SD.ssShoppingCartCount, cnt);
			}

			return View(IndexVM);
		}

		[Authorize]
		public async Task<IActionResult> Details(int id)
		{
			var productFromDb = await _db.Product.Include(m=>m.Category).Include(m => m.SubCategory).Where(m => m.Id == id).FirstOrDefaultAsync();

			ShoppingCart cartObj = new ShoppingCart()
			{
				Product = productFromDb,
				ProductId = productFromDb.Id
			};

			return View(cartObj);
		}

		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Details(ShoppingCart CartObject)
		{
			CartObject.Id = 0;
			if(ModelState.IsValid)
			{
				var claimsIdentity = (ClaimsIdentity)this.User.Identity;
				var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
				CartObject.ApplicationUserId = claim.Value;

				ShoppingCart cartFromDb = await _db.ShoppingCart.Where(c => c.ApplicationUserId == CartObject.ApplicationUserId 
												&& c.ProductId == CartObject.ProductId).FirstOrDefaultAsync();

				if(cartFromDb==null)
				{
					await _db.ShoppingCart.AddAsync(CartObject);
				}
				else
				{
					cartFromDb.Count = cartFromDb.Count + CartObject.Count;
				}
				await _db.SaveChangesAsync();

				var count = _db.ShoppingCart.Where(c => c.ApplicationUserId == CartObject.ApplicationUserId).ToList().Count();
				HttpContext.Session.SetInt32(SD.ssShoppingCartCount, count);

				return RedirectToAction("Index");
			}
			else
			{
				var productFromDb = await _db.Product.Include(m => m.Category).Include(m => m.SubCategory).Where(m => m.Id == CartObject.ProductId).FirstOrDefaultAsync();

				ShoppingCart cartObj = new ShoppingCart()
				{
					Product = productFromDb,
					ProductId = productFromDb.Id
				};

				return View(cartObj);
			
			}
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
