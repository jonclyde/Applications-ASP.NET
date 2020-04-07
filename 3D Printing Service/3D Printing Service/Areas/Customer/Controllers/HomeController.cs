﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _3D_Printing_Service.Models;
using _3D_Printing_Service.Data;
using _3D_Printing_Service.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace _3D_Printing_Service.Controllers
{
	[Area("Customer")]
	public class HomeController : Controller
	{

		private readonly ApplicationDbContext _db;

		public HomeController(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task<IActionResult> Index()
		{
			IndexViewModel IndexVM = new IndexViewModel()
			{
				Product = await _db.Product.Include(m => m.Category).Include(m => m.SubCategory).ToListAsync(),
				Category = await _db.Category.ToListAsync()
			};

			return View(IndexVM);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
