using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using organisation.Contracts;

namespace organisation.Controllers
{
    public class ListsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IListRepository _listRepo;

        public ListsController(IMapper mapper, IListRepository listRepository)
        {
            _listRepo = listRepository;
            _mapper = mapper;
        }

        // GET: Lists
        public ActionResult Index()
        {
            return View();
        }

        // GET: Lists/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Lists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lists/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Lists/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Lists/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Lists/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Lists/Delete/5
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