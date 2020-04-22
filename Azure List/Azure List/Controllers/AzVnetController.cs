using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Azure_List.Contracts;
using Azure_List.Data;
using Azure_List.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Azure_List.Controllers
{
    public class AzVnetController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IAzVnetRepository _azVnetRepo;
        private readonly IMapper _mapper;

        public AzVnetController(ApplicationDbContext db, IAzVnetRepository azVnetRepo, Mapper mapper)
        {
            _db = db;
            _azVnetRepo = azVnetRepo;
            _mapper = mapper;
        }

        // GET: AzVnet
        public async Task<ActionResult> Index()
        {
            var azVnets = await _azVnetRepo.FindAll();
            var model = _mapper.Map<List<AzVnetVM>>(azVnets);
            return View(model);
        }

        // GET: AzVnet/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AzVnet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AzVnet/Create
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

        // GET: AzVnet/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AzVnet/Edit/5
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

        // GET: AzVnet/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AzVnet/Delete/5
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