using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskList.Data;
using TaskList.Models.ViewModels;

namespace TaskList.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _db;

        [TempData]
        
        public string StatusMessage { get; set; }

        public TasksController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET Index
        public async Task<IActionResult> Index()
        {
            var Tasks = await _db.Tasks.Include(s => s.TaskCategory).ToListAsync();
            return View(Tasks);
        }

        //GET - Create
        public async Task<IActionResult> Create()
        {
            TaskAndTaskCategoryViewModel model = new TaskAndTaskCategoryViewModel()
            {
                TaskCategoryList = await _db.TaskCategory.ToListAsync(),
                Tasks = new Models.Tasks(),
                TasksList = await _db.Tasks.OrderBy(p=>p.Name).Select(p=>p.Name).Distinct().ToListAsync()
            };

            return View(model);

        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(TaskAndTaskCategoryViewModel model)
        {

        }

    }
}