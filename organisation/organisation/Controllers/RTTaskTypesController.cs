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

    public class RTTaskTypesController : Controller
        {
        private readonly ApplicationDbContext _db;
        private readonly IRunthroughTaskType _rtTaskTypeRepo;
        private readonly IMapper _mapper;

        public RTTaskTypesController(ApplicationDbContext db, IRunthroughTaskType rtTaskTypeRepo, IMapper mapper)
        {
            _db = db;
            _rtTaskTypeRepo = rtTaskTypeRepo;
            _mapper = mapper;
        }

        // GET: RTTaskTypes
        public async Task<ActionResult> Index()
        {
            var rtTaskTypes = await _rtTaskTypeRepo.FindAll();

            var model = _mapper.Map<List<RunthroughTaskType>, List<RunthroughTaskTypeVM>>(rtTaskTypes.ToList());
            return View(model);
        }

        // GET: RTTaskTypes/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var rtTaskType = await _rtTaskTypeRepo.FindById(id);

            if(rtTaskType == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<RunthroughTaskTypeVM>(rtTaskType);

            return View(model);
        }

        // GET: RTTaskTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RTTaskTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RunthroughTaskTypeVM model)
        {
            try
            {
                // TODO: Add insert logic here
                if(!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Model state is not valid");
                    return View();
                }

                var rtTaskType = _mapper.Map<RunthroughTaskType>(model);
                rtTaskType.DateCreated = DateTime.Now;

                var isSuccess = await _rtTaskTypeRepo.Create(rtTaskType);

                if(!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong adding the DB record");
                }

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message.ToString());
                return View(model);
            }
        }

        // GET: RTTaskTypes/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var isExists = await _rtTaskTypeRepo.isExists(id);

            if(!isExists)
            {
                return NotFound();
            }

            var rtTaskType = await _rtTaskTypeRepo.FindById(id);

            var model = _mapper.Map<RunthroughTaskTypeVM>(rtTaskType);

            return View(model);
        }

        // POST: RTTaskTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RunthroughTaskTypeVM model)
        {
            try
            {
                // TODO: Add update logic here
                if(!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Model state is not valid");
                    return View();
                }

                var rtTaskType = _mapper.Map<RunthroughTaskType>(model);

                var isSuccess = await _rtTaskTypeRepo.Update(rtTaskType);

                if(!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong updating the DB record");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message.ToString());
                return View();
            }
        }

        // GET: RTTaskTypes/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var rtTaskType = await _rtTaskTypeRepo.FindById(id);

            if(rtTaskType == null)
            {
                return NotFound();
            }

            var isSuccess = await _rtTaskTypeRepo.Delete(rtTaskType);

            if(!isSuccess)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: RTTaskTypes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}