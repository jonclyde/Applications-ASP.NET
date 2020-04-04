using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskList.Data;
using TaskList.Models;
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
            if (ModelState.IsValid)
            {
                var doesTaskExist = _db.Tasks.Include(s => s.TaskCategory).Where(s => s.Name == model.Tasks.Name && s.TaskCategory.Id == model.Tasks.TaskCategoryId);

                if(doesTaskExist.Count()>0)
                {
                    StatusMessage = "Error : Task already exists under" + doesTaskExist.First().TaskCategory.Name + ". Please create another.";
                }
                else
                {
                    _db.Tasks.Add(model.Tasks);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            TaskAndTaskCategoryViewModel modelVM = new TaskAndTaskCategoryViewModel()
            {
                TaskCategoryList = await _db.TaskCategory.ToListAsync(),
                Tasks = model.Tasks,
                TasksList = await _db.TaskCategory.OrderBy(p => p.Name).Select(p => p.Name).ToListAsync(),
                StatusMessage = StatusMessage
            };
            return View(modelVM);
        }

        [ActionName("GetTasks")]
        public async Task<IActionResult> GetTasks(int id)
        {
            List<Tasks> TaskList = new List<Tasks>();

            TaskList = await (from Tasks in _db.Tasks
                           where Tasks.TaskCategoryId == id
                           select Tasks).ToListAsync();
            return Json(new SelectList(TaskList, "Id", "Name"));
        }
        

    }
}