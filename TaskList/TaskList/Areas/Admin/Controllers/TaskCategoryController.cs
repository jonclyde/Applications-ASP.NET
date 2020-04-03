using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskList.Data;
using TaskList.Models;

namespace TaskList.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TaskCategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TaskCategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET
        public async Task<IActionResult> Index()
        {
            return View(await _db.TaskCategory.ToListAsync());
        }

        //GET- CREATE

        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(TaskCategory TaskCategory)
        {
            if(ModelState.IsValid)
            {
                _db.TaskCategory.Add(TaskCategory);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(TaskCategory);
        }

        //GET - EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var TaskCategory = await _db.TaskCategory.FindAsync(id);

            if(TaskCategory ==null)
            {
                return NotFound();
            }
            return View(TaskCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TaskCategory TaskCategory)
        {
            if(ModelState.IsValid)
            { 
                _db.Update(TaskCategory);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(TaskCategory);
        }

        //GET - DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if(id ==null)
            {
                return NotFound();
            }
            var TaskCategory = await _db.TaskCategory.FindAsync(id);

            if(TaskCategory == null)
            {
                return NotFound();
            }
            return View(TaskCategory);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var TaskCategory = await _db.TaskCategory.FindAsync(id);

            if(TaskCategory ==null)
            {
                return View();
            }

            _db.TaskCategory.Remove(TaskCategory);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //GET - DETAILS
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var TaskCategory = await _db.TaskCategory.FindAsync(id);
            if(TaskCategory==null)
            {
                return NotFound();
            }
            return View(TaskCategory);
        }
    }
}