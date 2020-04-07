using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using _3D_Printing_Service.Data;
using _3D_Printing_Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _3D_Printing_Service.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DiscountController : Controller
    {

        private readonly ApplicationDbContext _db;

        public DiscountController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Discount.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Discount discounts)
        {
            if(ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if(files.Count>0)
                {
                    byte[] p1 = null;
                    using(var fs1 = files[0].OpenReadStream())
                    {
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                    }
                    discounts.Picture = p1;
                }
                _db.Discount.Add(discounts);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(discounts);
        }

        //GET Edit Coupon
        public async Task<IActionResult> Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var discount = await _db.Discount.SingleOrDefaultAsync(m => m.Id == id);

            if(discount==null)
            {
                return NotFound();
            }
            return View(discount);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Discount discounts)
        {
            if(discounts.Id == 0)
            {
                return NotFound();
            }

            var discountFromDb = await _db.Discount.Where(c => c.Id == discounts.Id).FirstOrDefaultAsync();

            if(ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if(files.Count>0)
                {
                    byte[] p1 = null;
                    using (var fs1 = files[0].OpenReadStream())
                    {
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                    }
                    discountFromDb.Picture = p1;
                }
                discountFromDb.MinimumAmount = discounts.MinimumAmount;
                discountFromDb.Name = discounts.Name;
                discountFromDb.DiscountAmount = discounts.DiscountAmount;
                discountFromDb.DiscountType = discounts.DiscountType;
                discountFromDb.isActive = discounts.isActive;

                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(discounts);
        }

        //GET - Details
        public async Task<IActionResult> Details(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var discount = await _db.Discount
                .FirstOrDefaultAsync(m => m.Id == id);

            if(discount==null)
            {
                return NotFound();
            }
            return View(discount);
        }

        //GET Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if(id==null)
            {
                return NotFound();  
            }
            var discount = await _db.Discount.SingleOrDefaultAsync(m => m.Id == id);

            if(discount==null)
            {
                return NotFound();
            }

            return View(discount);
        }

        //POST delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var discounts = await _db.Discount.SingleOrDefaultAsync(m => m.Id == id);
            _db.Discount.Remove(discounts);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}