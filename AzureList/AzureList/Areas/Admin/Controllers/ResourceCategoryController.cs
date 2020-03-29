using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureList.Data;
using AzureList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzureList.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ResourceCategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ResourceCategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET INDEX
        public async Task<IActionResult> Index()
        {
            return View(await _db.ResourceCategory.ToListAsync());
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ResourceCategory ResourceCategory)
        {
            if(ModelState.IsValid)
            {
                //if valid
                _db.ResourceCategory.Add(ResourceCategory);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(ResourceCategory);
        }

        //GET - EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var ResourceCategory = await _db.ResourceCategory.FindAsync(id);
            if(ResourceCategory == null)
            {
                return NotFound();
            }
            return View(ResourceCategory);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ResourceCategory ResourceCategory)
        {
            if(ModelState.IsValid)
            {
                _db.Update(ResourceCategory);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ResourceCategory);
        }

        //GET - DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var ResourceCategory = await _db.ResourceCategory.FindAsync(id);
            if(ResourceCategory == null)
            {
                return NotFound();
            }
            return View(ResourceCategory);
        }

        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ResourceCategory = await _db.ResourceCategory.FindAsync(id);

            if(ResourceCategory==null)
            {
                return View();
            }
            _db.ResourceCategory.Remove(ResourceCategory);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}