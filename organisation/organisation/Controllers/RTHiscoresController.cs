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
    public class RTHiscoresController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IRunthroughHiscore _rtHiscoreRepo;

        public RTHiscoresController(ApplicationDbContext db, IMapper mapper, IRunthroughHiscore rtHiscoreRepo)
        {
            _db = db;
            _mapper = mapper;
            _rtHiscoreRepo = rtHiscoreRepo;
        }

        // GET: RTHiscore
        public async Task<ActionResult> Index()
        {
            var rtHiscores = await _rtHiscoreRepo.FindAll();
            var model = _mapper.Map<List<RunthroughHiscore>,List<RunthroughHiscoreVM>>(rtHiscores.ToList());
            return View(model);
        }

        // GET: RTHiscore/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var rtHiscore = await _rtHiscoreRepo.FindById(id);

            if(rtHiscore == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<RunthroughHiscoreVM>(rtHiscore);

            return View(model);
        }

        // GET: RTHiscore/Create
        public async Task<ActionResult> Create()
        {
            RunthroughHiscore model = new RunthroughHiscore()
            {
                Date = DateTime.Now
            };

            var isSuccess = await _rtHiscoreRepo.Create(model);

            if(!isSuccess)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: RTHiscore/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RunthroughHiscoreVM model)
        {
            try
            {
                // TODO: Add insert logic here
                if(!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Model state is not valid");
                    return View();
                }

                var rtHiscore = _mapper.Map<RunthroughHiscore>(model);

                var isSuccess = await _rtHiscoreRepo.Create(rtHiscore);

                if(!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong with creating the DB record");
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RTHiscore/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var rtHiscore = await _rtHiscoreRepo.FindById(id);

            if(rtHiscore == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<RunthroughHiscoreVM>(rtHiscore);

            return View(model);

        }

        // POST: RTHiscore/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RunthroughHiscoreVM model)
        {
            try
            {
                // TODO: Add update logic here
                if(!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Model state is not valid");
                    return View(model);
                }

                var rtHiscore = _mapper.Map<RunthroughHiscore>(model);
                var isSuccess = await _rtHiscoreRepo.Update(rtHiscore);

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
                return View(model);
            }
        }

        // GET: RTHiscore/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var rtHiScore = await _rtHiscoreRepo.FindById(id);

            if(rtHiScore == null)
            {
                return NotFound();
            }

            var isSuccess = await _rtHiscoreRepo.Delete(rtHiScore);

            if (!isSuccess)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: RTHiscore/Delete/5
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