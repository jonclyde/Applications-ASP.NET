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
    public class RTTaskController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IRunthroughTaskSection _rtTaskSectionsRepo;
        private readonly IRunthroughTaskStatus _rtTaskStatusesRepo;
        private readonly IRunthroughTaskType _rtTaskTypesRepo;
        private readonly IRunthroughTask _rtTaskRepo;
        private readonly IMapper _mapper;

        public RTTaskController(ApplicationDbContext db,
            IRunthroughTaskSection rtTaskSectionRepo,
            IRunthroughTaskStatus rtTaskStatusRepo,
            IRunthroughTaskType rtTaskTypeRepo,
            IRunthroughTask rtTaskRepo,
            IMapper mapper)
        {
            _db = db;
            _rtTaskSectionsRepo = rtTaskSectionRepo;
            _rtTaskStatusesRepo = rtTaskStatusRepo;
            _rtTaskTypesRepo = rtTaskTypeRepo;
            _rtTaskRepo = rtTaskRepo;
            _mapper = mapper;
        }

        // GET: RTTask
        public async Task<ActionResult> Index()
        {
            var rtTasks = await _rtTaskRepo.FindAll();

            var RTTasksModel = _mapper.Map<List<RunthroughTaskVM>>(rtTasks);

            var model = new AdminRunthroughTaskVM
            {
                TotalTasks = RTTasksModel.Count,
                RTTasks = RTTasksModel
            };

            return View(model);

        }

        // GET: RTTask/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var rtTask = await _rtTaskRepo.FindById(id);

            if(rtTask == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<RunthroughTaskVM>(rtTask);

            return View(model);
        }

        // GET: RTTask/Create
        public async Task<ActionResult> Create()
        {
            var rtTaskSections = await _rtTaskSectionsRepo.FindAll();
            var rtTaskStatuses = await _rtTaskStatusesRepo.FindAll();
            var rtTaskTypes = await _rtTaskTypesRepo.FindAll();

            var rtTaskSectionItems = rtTaskSections.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });
            var rtTaskStatusItems = rtTaskStatuses.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });
            var rtTaskTypeItems = rtTaskTypes.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });

            var model = new CreateRunthroughTaskVM
            {
                RTTaskSections = rtTaskSectionItems,
                RTTaskStatuses = rtTaskStatusItems,
                RTTaskTypes = rtTaskTypeItems
            };

            return View(model);

        }

        // POST: RTTask/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateRunthroughTaskVM model)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Model state is not valid");
                    return View(model);
                }
                var newOrderNumber = await _rtTaskRepo.GetNewOrderNumber();

                var rtTaskModel = new RunthroughTaskVM
                {
                    OrderNumber = newOrderNumber,
                    Name = model.Name,
                    RTTaskSectionId = model.RTTaskSectionId,
                    RTTaskStatusId = model.RTTaskStatusId,
                    RTTaskTypeId = model.RTTaskTypeId

                };

                var rtTask = _mapper.Map<RunthroughTask>(rtTaskModel);
                var isSuccess = await _rtTaskRepo.Create(rtTask);

                if(!isSuccess)
                {
                    ModelState.AddModelError("","Something went wrong creating the DB record");
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

        // GET: RTTask/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var rtTask = await _rtTaskRepo.FindById(id);

            if(rtTask == null)
            {
                return NotFound();
            }

            var rtTaskSections = await _rtTaskSectionsRepo.FindAll();
            var rtTaskStatuses = await _rtTaskStatusesRepo.FindAll();
            var rtTaskTypes = await _rtTaskTypesRepo.FindAll();

            var rtTaskSectionItems = rtTaskSections.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });
            var rtTaskStatusItems = rtTaskStatuses.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });
            var rtTaskTypeItems = rtTaskTypes.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });

            var model = _mapper.Map<CreateRunthroughTaskVM>(rtTask);

            model.RTTaskSections = rtTaskSectionItems;
            model.RTTaskStatuses = rtTaskStatusItems;
            model.RTTaskTypes = rtTaskTypeItems;

            return View(model);
        }

        // POST: RTTask/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CreateRunthroughTaskVM model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Model state is not valid");
                    return View(model);
                }

                var rtTask = await _rtTaskRepo.FindById(model.Id);
                rtTask.OrderNumber = model.OrderNumber;
                rtTask.Name = model.Name;
                rtTask.RTTaskSectionId = model.RTTaskSectionId;
                rtTask.RTTaskStatusId = model.RTTaskStatusId;
                rtTask.RTTaskTypeId = model.RTTaskTypeId;

                //var rtTask = _mapper.Map<RunthroughTask>(model);
                var isSuccess = await _rtTaskRepo.Update(rtTask);

                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong creating the DB record");
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

        // GET: RTTask/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var rtTask = await _rtTaskRepo.FindById(id);

            if(rtTask == null)
            {
                return NotFound();
            }

            var isSuccess = await _rtTaskRepo.Delete(rtTask);

            if(!isSuccess)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }
        
        // GET: RTTask/MoveDownOrder/5
        public async Task<ActionResult> MoveDownOrder(int id)
        {
            var rtTask = await _rtTaskRepo.FindById(id);

            var currentOrderNumber = rtTask.OrderNumber;

            await _rtTaskRepo.MoveDownOrder(currentOrderNumber);

            return RedirectToAction(nameof(Index));
        }
        // GET: RTTask/MoveUpOrder/5
        public async Task<ActionResult> MoveUpOrder(int id)
        {
            var rtTask = await _rtTaskRepo.FindById(id);

            var currentOrderNumber = rtTask.OrderNumber;

            await _rtTaskRepo.MoveUpOrder(currentOrderNumber);

            return RedirectToAction(nameof(Index));
        }

        // POST: RTTask/Delete/5
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