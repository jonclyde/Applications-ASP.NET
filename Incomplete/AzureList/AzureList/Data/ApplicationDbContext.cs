using System;
using System.Collections.Generic;
using System.Text;
using AzureList.Models;
using AzureList.Models.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AzureList.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<ResourceCategory> ResourceCategory {get; set;}

		public DbSet<ResourceProvider> ResourceProvider { get; set; }

		public DbSet<ResourceType> ResourceType { get; set; }
	}
}
