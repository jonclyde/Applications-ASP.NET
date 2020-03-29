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

        //GET
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
    }
}