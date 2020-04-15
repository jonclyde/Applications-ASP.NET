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
using organisation.Repository;

namespace organisation.Controllers
{
   
    public class RTTaskSectionsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IRunthroughTaskSection _rtTaskSectionRepo;
        private readonly IMapper _mapper;

        public RTTaskSectionsController (ApplicationDbContext db, IRunthroughTaskSection rtTaskSectionRepo, IMapper mapper)
        {
            _db = db;
            _rtTaskSectionRepo = rtTaskSectionRepo;
            _mapper = mapper;
        }


        // GET: RTTaskSections
        public async Task<ActionResult> Index()
        {
            var rtTaskSections = await _rtTaskSectionRepo.FindAll();
            var model = _mapper.Map<List<RunthroughTaskSection>, List<RunthroughTaskSectionVM>>(rtTaskSections.ToList());
            return View(model);
        }


        // GET: RTTaskSections/Detail
        public async Task<ActionResult> Details(int id)
        {
            var isExists = await _rtTaskSectionRepo.isExists(id);
            if(!isExists)
            {
                return NotFound();
            }
            var rtTaskSection = await _rtTaskSectionRepo.FindById(id);

            var model = _mapper.Map<RunthroughTaskSectionVM>(rtTaskSection);

            return View(model);

        }

        // GET: RTTaskSections/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RTTaskSections/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RunthroughTaskSectionVM model)
        {
            try
            {
                // TODO: Add insert logic here
                if(!ModelState.IsValid)
                {
                    return View(model);
                }

                var rtTaskSection = _mapper.Map<RunthroughTaskSection>(model);
                rtTaskSection.DateCreated = DateTime.Now;

                var isSuccess = await _rtTaskSectionRepo.Create(rtTaskSection);

                if(!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong adding the record to the database");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Try failed. Exception caught");
                ModelState.AddModelError("", ex.InnerException.Message.ToString());
                return View();
            }
        }

        // GET: RTTaskSections/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var isExists = await _rtTaskSectionRepo.isExists(id);

            if(!isExists)
            {
                return NotFound();
            }

            var rtTaskSection = await _rtTaskSectionRepo.FindById(id);

            var model = _mapper.Map<RunthroughTaskSectionVM>(rtTaskSection);

            return View(model);

        }

        // POST: RTTaskSections/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RunthroughTaskSectionVM model)
        {
            try
            {
                // TODO: Add update logic here
                if(!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Model state is not valid");
                    return View();
                }

                var rtTaskSection = _mapper.Map<RunthroughTaskSection>(model);
                var isSuccess = await _rtTaskSectionRepo.Update(rtTaskSection);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Try failed. Exception caught");
                ModelState.AddModelError("", ex.InnerException.Message.ToString());
                return View();
            }
        }

        // GET: RTTaskSections/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var rtTaskSection = await _rtTaskSectionRepo.FindById(id);

            if (rtTaskSection == null)
            {
                return NotFound();
            }

            var isSuccess = await _rtTaskSectionRepo.Delete(rtTaskSection);

            if(!isSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: RTTaskSections/Delete/5
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