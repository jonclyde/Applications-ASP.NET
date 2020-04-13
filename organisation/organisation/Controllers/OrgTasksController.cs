using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using organisation.Contracts;
using organisation.Models;

namespace organisation.Controllers
{
    public class OrgTasksController : Controller
    {

        private readonly IOrgTaskRepository _orgTaskRepo;
        private readonly ITaskTypeRepository _taskTypeRepo;
        private readonly IMapper _mapper;

        public OrgTasksController(IOrgTaskRepository orgTaskRepo, ITaskTypeRepository taskTypeRepo, IMapper mapper)
        {
            _orgTaskRepo = orgTaskRepo;
            _taskTypeRepo = taskTypeRepo;
            _mapper = mapper;
        }
        // GET: OrgTasks
        public async Task<ActionResult> Index()
        {
            var orgTasks = await _orgTaskRepo.FindAll();
            var orgTasksModel = _mapper.Map<List<OrgTaskVM>>(orgTasks);
            var model = new OrgTaskVM
            {
            //    TotalRequests = leaveRequestsModel.Count,
            //    ApprovedRequests = leaveRequestsModel.Count(q => q.Approved == true),
            //    PendingRequests = leaveRequestsModel.Count(q => q.Approved == null),
            //    RejectedRequests = leaveRequestsModel.Count(q => q.Approved == false),
                OrgTasks = orgTasksModel

            };
            return View(model);
        }

        // GET: OrgTasks/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrgTasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrgTasks/Create
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

        // GET: OrgTasks/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrgTasks/Edit/5
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

        // GET: OrgTasks/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrgTasks/Delete/5
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