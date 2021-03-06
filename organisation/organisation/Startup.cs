using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using organisation.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using organisation.Contracts;
using organisation.Repository;
using AutoMapper;
using organisation.Mappings;

namespace organisation
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(
					Configuration.GetConnectionString("DefaultConnection")));
			services.AddScoped<ITaskTypeRepository, TaskTypeRepository>();
			services.AddScoped<IOrgTaskRepository, OrgTaskRepository>();
			services.AddScoped<IOrgGoalRepository, OrgGoalRepository>();
			services.AddScoped<IRunthroughTaskSection, RunthroughTaskSectionRepository>();
			services.AddScoped<IRunthroughTaskStatus, RunthroughTaskStatusRepository>();
			services.AddScoped<IRunthroughTaskType, RunthroughTaskTypeRepository>();
			services.AddScoped<IRunthroughHiscore, RunthroughHiscoreRepository>();
			services.AddScoped<ICodeCountRepository, CodeCountRepository>();
			services.AddScoped<IRunthroughTask, RunthroughTaskRepository>();
			services.AddScoped<IListRepository, ListRepository>();
			services.AddAutoMapper(typeof(Maps));
			services.AddDefaultIdentity<IdentityUser>()
				.AddEntityFrameworkStores<ApplicationDbContext>();
			services.AddControllersWithViews();
			services.AddRazorPages();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
				endpoints.MapRazorPages();
			});
		}
	}
}
