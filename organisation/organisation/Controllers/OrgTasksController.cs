using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using organisation.Contracts;
using organisation.Data;
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
            var model = new AdminOrgTasksVM
            {
                TotalTasks = orgTasksModel.Count,
                Q1Tasks = orgTasksModel.Where(q => q.Importance == 1 && q.Urgency == 1).Count(),
                Q2Tasks = orgTasksModel.Where(q => q.Importance == 1 && q.Urgency == 2).Count(),
                Q3Tasks = orgTasksModel.Where(q => q.Importance == 2 && q.Urgency == 1).Count(),
                Q4Tasks = orgTasksModel.Where(q => q.Importance == 2 && q.Urgency == 2).Count(),
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
        public async Task<ActionResult> Create()
        {
            var taskTypes = await _taskTypeRepo.FindAll();
            var taskTypeItems = taskTypes.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });
            var model = new UpsertOrgTaskVM
            {
                TaskTypes = taskTypeItems
            };
            return View(model);
        }

        // POST: OrgTasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UpsertOrgTaskVM model)
        {
            try
            {
                //var endDate = Convert.ToDateTime(model.EndDate);
                //var deadLine = Convert.ToDateTime(model.DeadLine);
                var endDate = model.EndDate;
                var deadLine = model.DeadLine;
                var urgency = model.Urgency;
                var importance = model.Importance;
                var difficulty = model.Difficulty;

                var taskTypes = await _taskTypeRepo.FindAll();
                var taskTypeItems = taskTypes.Select(q => new SelectListItem
                {
                    Text = q.Name,
                    Value = q.Id.ToString()
                });
                model.TaskTypes = taskTypeItems;

                if(!ModelState.IsValid)
                {
                    return View(model);
                }

                if(DateTime.Compare(endDate, deadLine) > 1)
                {
                    ModelState.AddModelError("", "Deadline must come after the end date");
                    return View(model);
                }

                int quadrant;

                if(importance == 1 && urgency == 1)
                {
                    quadrant = 1;
                }
                else
                {
                    if(importance == 1 && urgency == 2)
                    {
                        quadrant = 2;
                    }
                    else
                    {
                        if(importance == 2 && urgency == 1)
                        {
                            quadrant = 3;
                        }
                        else
                        {
                            if (importance == 2 && urgency == 2)
                            {
                                quadrant = 4;
                            }
                            else
                            {
                                ModelState.AddModelError("", "Urgency and importance must both be set to 1 or 2");
                                return View(model);
                            }
                        }
                    }
                }
                double precalc = quadrant / difficulty;
                double score = precalc * 10;


                var orgTaskModel = new OrgTaskVM
                {
                    Name = model.Name,
                    Urgency = model.Urgency,
                    Importance = model.Importance,
                    Difficulty = model.Difficulty,
                    Score = score,
                    DateCreated = DateTime.Now,
                    EndDate = endDate,
                    DeadLine = deadLine,
                    Status = null,
                    TaskTypeId = model.TaskTypeId,
                    DateComplete = DateTime.Now
                };

                var orgTask = _mapper.Map<OrgTask>(orgTaskModel);
                var isSuccess = await _orgTaskRepo.Create(orgTask);

                if(!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong with submitting your record");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.InnerException.Message.ToString());
            }
        }

        // GET: OrgTasks/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var isExists = await _orgTaskRepo.isExists(id);

            if (!isExists)
            {
                return NotFound();
            }
            
            var taskTypes = await _taskTypeRepo.FindAll();
            var orgTask = await _orgTaskRepo.FindById(id);

            var taskTypeItems = taskTypes.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });
            var model = new UpsertOrgTaskVM
            {
                OrgTask = orgTask,
                TaskTypes = taskTypeItems
            };
                        
            return View(model);
        }

        // POST: OrgTasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpsertOrgTaskVM model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View(model);
                }

                var orgTask = _mapper.Map<OrgTask>(model);
                var isSuccess = await _orgTaskRepo.Update(orgTask);

                if(!isSuccess)
                {
                    ModelState.AddModelError("", "Something Went Wrong");
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