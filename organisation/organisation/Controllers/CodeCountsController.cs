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
    public class CodeCountsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ICodeCountRepository _codeCountRepo;
        private readonly IMapper _mapper;

        public CodeCountsController(ApplicationDbContext db, ICodeCountRepository codeCountRepository, IMapper mapper)
        {
            _db = db;
            _codeCountRepo = codeCountRepository;
            _mapper = mapper;
        }


        // GET: CodeCount
        public async Task<ActionResult> Index()
        {
            var codeCounts = await _codeCountRepo.FindAll();
            var model = _mapper.Map<List<CodeCount>, List<CodeCountVM>>(codeCounts.ToList());
            return View(model);
        }

        // GET: CodeCount/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var codeCount = await _codeCountRepo.FindById(id);

            if(codeCount == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<CodeCountVM>(codeCount);

            return View(model);
        }

        // GET: CodeCount/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: CodeCount/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CodeCountVM model)
        {
            try
            {
                // TODO: Add insert logic here
                if(!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Model state is not valid");
                    return View(model);
                }

                var codeCount = _mapper.Map<CodeCount>(model);
                var isSuccess = await _codeCountRepo.Create(codeCount);

                if(!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong creating the DB record");
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

        // GET: CodeCount/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var codeCount = await _codeCountRepo.FindById(id);

            if(codeCount == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<CodeCountVM>(codeCount);

            return View(model);

        }

        // POST: CodeCount/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CodeCountVM model)
        {
            try
            {
                // TODO: Add update logic here
                if(!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Model state is not valid");
                    return View(model);
                }

                var codeCount = _mapper.Map<CodeCount>(model);
                var isSuccess = await _codeCountRepo.Update(codeCount);

                if(!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong updating the DB record");
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

        // GET: CodeCount/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var codeCount = await _codeCountRepo.FindById(id);

            if(codeCount == null)
            {
                return NotFound();
            }

            var isSuccess = await _codeCountRepo.Delete(codeCount);

            if(!isSuccess)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: CodeCount/Delete/5
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