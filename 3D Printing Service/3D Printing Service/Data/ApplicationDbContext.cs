using System;
using System.Collections.Generic;
using System.Text;
using _3D_Printing_Service.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _3D_Printing_Service.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Category> Category { get; set; }
		public DbSet<SubCategory> SubCategory { get; set; }
		public DbSet<Product> Product { get; set; }
		public DbSet<Discount> Discount { get; set; }
		public DbSet<ApplicationUser> ApplicationUser { get; set; }
		public DbSet<ShoppingCart> ShoppingCart { get; set; }
		public DbSet<OrderHeader> OrderHeader { get; set; }
		public DbSet<OrderDetails> OrderDetails { get; set; }
	}
}
