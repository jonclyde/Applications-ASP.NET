using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using organisation.Contracts;
using organisation.Data;
using organisation.Models;

namespace organisation.Controllers
{
    public class TaskTypesController : Controller
    {
        private readonly ITaskTypeRepository _repo;
        private readonly IMapper _mapper;

        public TaskTypesController(ITaskTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: TaskTypes
        public async Task<ActionResult> Index()
        {
            var taskTypes = await _repo.FindAll();
            var model = _mapper.Map<List<TaskType>, List<TaskTypeVM>>(taskTypes.ToList());
            return View(model);
        }

        // GET: TaskTypes/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var isExists = await _repo.isExists(id);
            if(!isExists)
            {
                return NotFound();
            }
            var taskType = await _repo.FindById(id);
            var model = _mapper.Map<TaskTypeVM>(taskType);
            return View(model);
        }

        // GET: TaskTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TaskTypeVM model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View(model);
                }

                var taskType = _mapper.Map<TaskType>(model);
                taskType.DateCreated = DateTime.Now;

                var isSuccess = await _repo.Create(taskType);

                if(!isSuccess)
                {
                    ModelState.AddModelError("", "Something Went Wrong");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong");
                return View(model);
            }
        }

        // GET: TaskTypes/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var isExists = await _repo.isExists(id);
            if(!isExists)
            {
                return NotFound();
            }
            var taskType = await _repo.FindById(id);
            var model = _mapper.Map<TaskTypeVM>(taskType);
            return View(model);
        }

        // POST: TaskTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TaskTypeVM model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View(model);
                }
                var taskType = _mapper.Map<TaskType>(model);
                var isSuccess = await _repo.Update(taskType);
                if(!isSuccess)
                {
                    ModelState.AddModelError("", "Something Went Wrong...");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View(model);
            }
        }

        // GET: TaskTypes/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var taskType = await _repo.FindById(id);
            if(taskType == null)
            {
                return NotFound();
            }
            var isSuccess = await _repo.Delete(taskType);
            if(!isSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: TaskTypes/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Delete(int id, TaskTypeVM model)
        //{
        //    try
        //    {
        //        var taskType = await _repo.FindById(id);
        //        if(taskType == null)
        //        {
        //            return NotFound();
        //        }
        //        var isSuccess = await _repo.Delete(taskType);
        //        if(!isSuccess)
        //        {
        //            return View(model);
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}