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
	}
}
