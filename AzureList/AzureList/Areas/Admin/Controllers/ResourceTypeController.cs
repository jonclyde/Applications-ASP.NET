using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureList.Data;
using AzureList.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzureList.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ResourceTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public ResourceTypeViewModel ResourceTypeVM { get; set; }
        [TempData]

        public string StatusMessage { get; set; }

        public ResourceTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET INDEX
        public async Task<IActionResult> Index()
        {
            var ResourceTypes = await _db.ResourceType.Include(s => s.ResourceCategory).Include(s => s.ResourceProvider).ToListAsync();
            return View(ResourceTypes);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View(ResourceTypeVM);
        }
    }
}