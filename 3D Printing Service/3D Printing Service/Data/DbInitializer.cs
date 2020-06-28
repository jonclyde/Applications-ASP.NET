using _3D_Printing_Service.Models;
using _3D_Printing_Service.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3D_Printing_Service.Data
{
	public class DbInitializer : IDbInitializer
	{
		private readonly ApplicationDbContext _db;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_db = db;
			_roleManager = roleManager;
			_userManager = userManager;
		}

		public async void Initialize()
		{
			try
			{
				if (_db.Database.GetPendingMigrations().Count() > 0)
				{
					_db.Database.Migrate();
				}
			}
			catch (Exception ex)
			{

			}

			if (_db.Roles.Any(r => r.Name == SD.ManagerUser)) return;
			
			_roleManager.CreateAsync(new IdentityRole(SD.ManagerUser)).GetAwaiter().GetResult();
			_roleManager.CreateAsync(new IdentityRole(SD.FrontDeskUser)).GetAwaiter().GetResult();
			_roleManager.CreateAsync(new IdentityRole(SD.PrinterUser)).GetAwaiter().GetResult();
			_roleManager.CreateAsync(new IdentityRole(SD.CustomerEndUser)).GetAwaiter().GetResult();

			_userManager.CreateAsync(new ApplicationUser
			{
				UserName = "admin@jcly.de",
				Email = "admin@jcly.de",
				FirstName = "Jon",
				LastName = "Clyde",
				EmailConfirmed = true,
				PhoneNumber = "+448007387232"
			}, "P@ssw0rd2").GetAwaiter().GetResult();

			IdentityUser user = await _db.Users.FirstOrDefaultAsync(u => u.Email == "admin@jcly.de");

			await _userManager.AddToRoleAsync(user, SD.ManagerUser);
			
			//Computer category
			//var compCat = new Category
			//{
			//	Name = "Computers"
			//};
			//await _db.Category.AddAsync(compCat);

			//var compCatId = compCat.Id;

			//	//Laptop subcategory
			//	var laptopsSubCat = new SubCategory
			//	{
			//		Name = "Laptops",
			//		CategoryId = compCatId
			//	};

			//	await _db.SubCategory.AddAsync(laptopsSubCat);

			//	var laptopSubCatId = laptopsSubCat.Id;

			//	//Laptop products
			//	var dellXPS = new Product
			//	{
			//		Name = "Dell XPS 13",
			//		Description = "Explore Best-in-class Aesthetics and Highest Resolution Displays. Powered by Intel Core. Powerful Processors. Streamlined Design. Amazing Battery Life. Super Lightweight.",
			//		Image = "\\images\\1.jpg",
			//		CategoryId = compCatId,
			//		SubCategoryId = laptopSubCatId,
			//		Price = 1200
			//	};

			//	await _db.Product.AddAsync(dellXPS);
		}
	}
}
