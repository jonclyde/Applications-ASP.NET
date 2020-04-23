using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace organisation.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<OrgTask> OrgTasks { get; set; }
		public DbSet<TaskType> TaskTypes { get; set; }

		public DbSet<OrgGoal> OrgGoals { get; set; }
		public DbSet<RunthroughTaskSection> RunthroughTaskSections { get; set; }
		public DbSet<RunthroughTaskStatus> RunthroughTaskStatuses { get; set; }
		public DbSet<RunthroughTaskType> RunthroughTaskTypes { get; set; }
		public DbSet<RunthroughHiscore> RunthroughHiscores { get; set; }
		public DbSet<CodeCount> CodeCounts { get; set; }
		public DbSet<RunthroughTask> RunthroughTask { get; set; }
		public DbSet<List> Lists { get; set; }
	}
}
