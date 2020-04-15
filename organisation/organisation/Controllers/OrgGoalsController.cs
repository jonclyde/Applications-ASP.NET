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
    public class OrgGoalsController : Controller
    {
        private readonly IOrgGoalRepository _orgGoalRepo;
        private readonly IMapper _mapper;

        public OrgGoalsController(IOrgGoalRepository orgGoalRepo, IMapper mapper)
        {
            _orgGoalRepo = orgGoalRepo;
            _mapper = mapper;
        }

        // GET: OrgGoals
        public async Task<ActionResult> Index()
        {
            var orgGoals = await _orgGoalRepo.FindAll();
            var model = _mapper.Map<List<OrgGoal>, List<OrgGoalVM>>(orgGoals.ToList());
            return View(model);
        }

        // GET: OrgGoals/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var isExists = await _orgGoalRepo.isExists(id);
            if (!isExists)
            {
                return NotFound();
            }
            var orgGoal = await _orgGoalRepo.FindById(id);
            var model = _mapper.Map<OrgGoalVM>(orgGoal);
            return View(model);
        }

        // GET: OrgGoals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrgGoals/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(OrgGoalVM model)
        {
            try
            {
                // TODO: Add insert logic here
                if(!ModelState.IsValid)
                {
                    return View(model);
                }
                var orgGoal = _mapper.Map<OrgGoal>(model);
                orgGoal.DateCreated = DateTime.Now;

                var isSuccess = await _orgGoalRepo.Create(orgGoal);

                if(!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong creating the database record");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Something went wrong");
                return View(model);
            }
        }

        // GET: OrgGoals/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var isExists = await _orgGoalRepo.isExists(id);
            if(!isExists)
            {
                return NotFound();
            }
            var orgGoal = await _orgGoalRepo.FindById(id);
            var model = _mapper.Map<OrgGoalVM>(orgGoal);
            return View(model);

        }

        // POST: OrgGoals/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(OrgGoalVM model)
        {
            try
            {
                // TODO: Add update logic here
                if(!ModelState.IsValid)
                {
                    return View(model);
                }
                var orgGoal = _mapper.Map<OrgGoal>(model);
                var isSuccess = await _orgGoalRepo.Update(orgGoal);

                if(!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong updating the database record");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.InnerException.Message.ToString());
                return View(model);
            }
        }

        // GET: OrgGoals/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var orgGoal = await _orgGoalRepo.FindById(id);
            if(orgGoal == null)
            {
                return NotFound();
            }
            var isSuccess = await _orgGoalRepo.Delete(orgGoal);
            if(!isSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: OrgGoals/Delete/5
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

        public async Task<ActionResult> CompleteGoal(int id)
        {
            var orgGoal = await _orgGoalRepo.FindById(id);
            if(orgGoal == null)
            {
                return NotFound();
            }

            orgGoal.Status = true;

            await _orgGoalRepo.Update(orgGoal);

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> IncompleteGoal(int id)
        {
            var orgGoal = await _orgGoalRepo.FindById(id);

            if(orgGoal == null)
            {
                return NotFound();
            }

            orgGoal.Status = false;

            await _orgGoalRepo.Update(orgGoal);

            return RedirectToAction(nameof(Index));
        }
    }
}