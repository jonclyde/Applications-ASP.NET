﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using leave_management.Contracts;
using leave_management.Data;
using leave_management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace leave_management.Controllers
{
	[Authorize]
	public class LeaveRequestController : Controller
	{
		private readonly ILeaveRequestRepository _leaveRequestRepo;
		private readonly ILeaveTypeRepository _leaveTypeRepo;
		private readonly ILeaveAllocationRepository _leaveAllocRepo;
		private readonly IMapper _mapper;
		private readonly UserManager<Employee> _userManager;

		public LeaveRequestController(
			ILeaveRequestRepository leaveRequestRepo,
			ILeaveTypeRepository leaveTypeRepo,
			ILeaveAllocationRepository leaveAllocRepo,
			IMapper mapper,
			UserManager<Employee> userManager
		)
		{
			_leaveRequestRepo = leaveRequestRepo;
			_leaveTypeRepo = leaveTypeRepo;
			_leaveAllocRepo = leaveAllocRepo;
			_mapper = mapper;
			_userManager = userManager;
		}

		[Authorize(Roles = "Administrator")]
		// GET: LeaveRequest
		public ActionResult Index()
		{
			var leaveRequests = _leaveRequestRepo.FindAll();
			var leaveRequestsModel = _mapper.Map<List<LeaveRequestVM>>(leaveRequests);
			var model = new AdminLeaveRequestViewVM
			{
				TotalRequests = leaveRequestsModel.Count,
				ApprovedRequests = leaveRequestsModel.Count(q => q.Approved == true),
				PendingRequests = leaveRequestsModel.Count(q => q.Approved == null),
				RejectedRequests = leaveRequestsModel.Count(q => q.Approved == false),
				LeaveRequests = leaveRequestsModel

			};
			return View(model);
		}

		// GET: LeaveRequest/Details/5
		public ActionResult Details(int id)
		{
			var leaveRequest = _leaveRequestRepo.FindById(id);
			var model = _mapper.Map<LeaveRequestVM>(leaveRequest);
			return View(model);
		}

		public ActionResult ApproveRequest(int id)
		{
			try
			{
				var user = _userManager.GetUserAsync(User).Result;
				var leaveRequest = _leaveRequestRepo.FindById(id);
				var employeeid = leaveRequest.RequestingEmployeeId;
				var leaveTypeId = leaveRequest.LeaveTypeId;
				var allocation = _leaveAllocRepo.GetLeaveAllocationsbyEmployeeAndType(employeeid,leaveTypeId);
				int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
				allocation.NumberOfDays -= daysRequested;

				leaveRequest.Approved = true;
				leaveRequest.ApprovedById = user.Id;
				leaveRequest.DateActioned = DateTime.Now;

				_leaveRequestRepo.Update(leaveRequest);
				_leaveAllocRepo.Update(allocation);
				
				return RedirectToAction(nameof(Index));
				
			}
			catch (Exception ex)
			{
				return RedirectToAction(nameof(Index));
			}

		}

		public ActionResult RejectRequest(int id)
		{
			try
			{
				var user = _userManager.GetUserAsync(User).Result;
				var leaveRequest = _leaveRequestRepo.FindById(id);
				leaveRequest.Approved = false;
				leaveRequest.ApprovedById = user.Id;
				leaveRequest.DateActioned = DateTime.Now;

				_leaveRequestRepo.Update(leaveRequest);

				return RedirectToAction(nameof(Index));

			}
			catch (Exception ex)
			{
				return RedirectToAction(nameof(Index));
			}
		}

		// GET: LeaveRequest/Create
		public ActionResult Create()
		{
			var leaveTypes = _leaveTypeRepo.FindAll();
			var leaveTypeItems = leaveTypes.Select(q => new SelectListItem
			{
				Text = q.Name,
				Value = q.Id.ToString()
			});
			var model = new CreateLeaveRequestVM
			{
				LeaveTypes = leaveTypeItems
			};
			return View(model);
		}

		// POST: LeaveRequest/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(CreateLeaveRequestVM model)
		{

			try
			{
				var startDate = Convert.ToDateTime(model.StartDate);
				var endDate = Convert.ToDateTime(model.EndDate);
				var leaveTypes = _leaveTypeRepo.FindAll();
				var leaveTypeItems = leaveTypes.Select(q => new SelectListItem
				{
					Text = q.Name,
					Value = q.Id.ToString()
				});
				model.LeaveTypes = leaveTypeItems;

				if (!ModelState.IsValid)
				{
					return View(model);
				}

				if (DateTime.Compare(startDate, endDate) > 1)
				{
					ModelState.AddModelError("", "Start date cannot be further in the future than end date");
					return View(model);
				}

				var employee = _userManager.GetUserAsync(User).Result;
				var allocation = _leaveAllocRepo.GetLeaveAllocationsbyEmployeeAndType(employee.Id, model.LeaveTypeId);
				int daysRequested = (int)(endDate - startDate).TotalDays;

				if (daysRequested > allocation.NumberOfDays)
				{
					ModelState.AddModelError("", "You do not have sufficent days");
					return View(model);
				}

				var leaveRequestModel = new LeaveRequestVM
				{
					RequestingEmployeeId = employee.Id,
					StartDate = startDate,
					EndDate = endDate,
					Approved = null,
					DateRequested = DateTime.Now,
					DateActioned = DateTime.Now,
					LeaveTypeId = model.LeaveTypeId
				};

				var leaveRequest = _mapper.Map<LeaveRequest>(leaveRequestModel);
				var isSuccess = _leaveRequestRepo.Create(leaveRequest);

				if (!isSuccess)
				{
					ModelState.AddModelError("", "Something went wrong with submitting your record");
					return View(model);
				}

				return RedirectToAction(nameof(Index), "Home");
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", ex.InnerException.Message.ToString());
				return View(model);
			}
		}

		// GET: LeaveRequest/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: LeaveRequest/Edit/5
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

		// GET: LeaveRequest/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: LeaveRequest/Delete/5
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