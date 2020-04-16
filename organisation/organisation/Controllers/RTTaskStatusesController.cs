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
    public class RTTaskStatusesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IRunthroughTaskStatus _rtTaskStatusRepo;
        private readonly IMapper _mapper;

        public RTTaskStatusesController(ApplicationDbContext db, IRunthroughTaskStatus rtTaskStatusRepo, IMapper mapper)
        {
            _db = db;
            _rtTaskStatusRepo = rtTaskStatusRepo;
            _mapper = mapper;
        }

        // GET: RTTaskStatuses
        public async Task<ActionResult> Index()
        {
            var rtTaskStatuses = await _rtTaskStatusRepo.FindAll();
            var model = _mapper.Map<List<RunthroughTaskStatus>, List<RunthroughTaskStatusVM>>(rtTaskStatuses.ToList());

            return View(model);
        }

        // GET: RTTaskStatuses/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var rtTaskStatus = await _rtTaskStatusRepo.FindById(id);

            if(rtTaskStatus == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<RunthroughTaskStatusVM>(rtTaskStatus);

            return View(model);
        }

        // GET: RTTaskStatuses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RTTaskStatuses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RunthroughTaskStatusVM model)
        {
            try
            {
                // TODO: Add insert logic here
                if(!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Mode state is not valid");
                    return View();
                }


                var rtTaskStatus = _mapper.Map<RunthroughTaskStatus>(model);
                rtTaskStatus.DateCreated = DateTime.Now;

                var isSuccess = await _rtTaskStatusRepo.Create(rtTaskStatus);

                if(!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong adding the database record");
                }

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Try failed. Exception caught");
                ModelState.AddModelError("", ex.Message.ToString());
                return View();
            }
        }

        // GET: RTTaskStatuses/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            // TODO: Add update logic here
            var isExists = await _rtTaskStatusRepo.isExists(id);

            if (!isExists)
            {
                return NotFound();
            }

            var rtTaskStatus = await _rtTaskStatusRepo.FindById(id);
            var model = _mapper.Map<RunthroughTaskStatusVM>(rtTaskStatus);

            return View(model);
        }

        // POST: RTTaskStatuses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RunthroughTaskStatusVM model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Model state is not valid");
                    return View(model);
                }

                var rtTaskStatus = _mapper.Map<RunthroughTaskStatus>(model);

                var isSuccess = await _rtTaskStatusRepo.Update(rtTaskStatus);

                if(!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong updating the DB record");
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

        // GET: RTTaskStatuses/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var rtTaskStatus = await _rtTaskStatusRepo.FindById(id);

            if(rtTaskStatus == null)
            {
                return NotFound();
            }

            var isSuccess = await _rtTaskStatusRepo.Delete(rtTaskStatus);

            if(!isSuccess)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: RTTaskStatuses/Delete/5
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