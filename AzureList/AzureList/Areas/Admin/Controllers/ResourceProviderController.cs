using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureList.Data;
using AzureList.Models;
using AzureList.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AzureList.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ResourceProviderController : Controller
    {
        private readonly ApplicationDbContext _db;

        [TempData]

        public string StatusMessage { get; set; }

        public ResourceProviderController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET INDEX

        public async Task<IActionResult> Index()
        {
            var ResourceProviders = await _db.ResourceProvider.Include(s => s.ResourceCategory).ToListAsync();
            return View(ResourceProviders);
        }

        //GET - CREATE
        public async Task<IActionResult> Create()
        {
            ResourceProviderAndResourceCategoryViewModel model = new ResourceProviderAndResourceCategoryViewModel()
            {
                ResourceCategoryList = await _db.ResourceCategory.ToListAsync(),
                ResourceProvider = new Models.ResourceProvider(),
                ResourceProviderList = await _db.ResourceProvider.OrderBy(p => p.Name).Select(p => p.Name).Distinct().ToListAsync()
            };
            return View(model);
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ResourceProviderAndResourceCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var doesResourceProviderExists = _db.ResourceProvider.Include(s => s.ResourceCategory).Where(s => s.Name == model.ResourceProvider.Name);

                if(doesResourceProviderExists.Count() > 0)
                {
                    StatusMessage = "Error : Resource provider " + model.ResourceProvider.Name + " already exists under " + doesResourceProviderExists.First().ResourceCategory.Name + " resource category";
                }
                else
                {
                    _db.ResourceProvider.Add(model.ResourceProvider);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ResourceProviderAndResourceCategoryViewModel modelVM = new ResourceProviderAndResourceCategoryViewModel()
            {
                ResourceCategoryList = await _db.ResourceCategory.ToListAsync(),
                ResourceProvider = model.ResourceProvider,
                ResourceProviderList = await _db.ResourceProvider.OrderBy(p => p.Name).Select(p => p.Name).ToListAsync(),
                StatusMessage = StatusMessage
            };
            return View(modelVM);
        }

        [ActionName("GetResourceProvider")]
        public async Task<IActionResult> GetResourceProvider(int id)
        {
            List<ResourceProvider> ResourceProviders = new List<ResourceProvider>();

            ResourceProviders = await (from ResourceProvider in _db.ResourceProvider
                                       where ResourceProvider.ResourceCategoryId == id
                                       select ResourceProvider).ToListAsync();
            return Json(new SelectList(ResourceProviders, "Id", "Name"));
        }

        //GET - EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var resourceProvider = await _db.ResourceProvider.SingleOrDefaultAsync(m => m.Id == id);

            if(resourceProvider==null)
            {
                return NotFound();
            }

            ResourceProviderAndResourceCategoryViewModel model = new ResourceProviderAndResourceCategoryViewModel()
            {
                ResourceCategoryList = await _db.ResourceCategory.ToListAsync(),
                ResourceProvider = resourceProvider,
                ResourceProviderList = await _db.ResourceProvider.OrderBy(p => p.Name).Select(p => p.Name).Distinct().ToListAsync()
            };
            return View(model);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ResourceProviderAndResourceCategoryViewModel model)
        {
            if(ModelState.IsValid)
            {
                var doesResourceProviderExists = _db.ResourceProvider.Include(s => s.ResourceCategory).Where(s => s.Name == model.ResourceProvider.Name);
                
                if(doesResourceProviderExists.Count()>0)
                {
                    StatusMessage = "Error : Resource provider " + model.ResourceProvider.Name + " already exists under " + doesResourceProviderExists.First().ResourceCategory.Name + " resource category";
                }
                else
                {
                    var ResourceProviderFromDb = await _db.ResourceProvider.FindAsync(model.ResourceProvider.Id);
                    ResourceProviderFromDb.Name = model.ResourceProvider.Name;

                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ResourceProviderAndResourceCategoryViewModel modelVM = new ResourceProviderAndResourceCategoryViewModel()
            {
                ResourceCategoryList = await _db.ResourceCategory.ToListAsync(),
                ResourceProvider = model.ResourceProvider,
                ResourceProviderList = await _db.ResourceProvider.OrderBy(p=>p.Name).Select(p=>p.Name).ToListAsync(),
                StatusMessage = StatusMessage
            };
            return View(modelVM);
        }

        //GET - DETAILS
        public async Task<IActionResult> Details(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var ResourceProvider = await _db.ResourceProvider.Include(s => s.ResourceCategory).SingleOrDefaultAsync(m => m.Id == id);

            if(ResourceProvider==null)
            {
                return NotFound();
            }
            return View(ResourceProvider);
        }

        //GET - DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var ResourceProvider = await _db.ResourceProvider.Include(s => s.ResourceCategory).SingleOrDefaultAsync(m => m.Id == id);
            if(ResourceProvider==null)
            {
                return NotFound();
            }
            return View(ResourceProvider);
        }

        //POST Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ResourceProvider = await _db.ResourceProvider.SingleOrDefaultAsync(m => m.Id == id);
            _db.ResourceProvider.Remove(ResourceProvider);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
     }
}