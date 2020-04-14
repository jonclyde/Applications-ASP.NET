using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using organisation.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace organisation.Models
{
	public class OrgTaskVM
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
		public int Urgency { get; set; }
		public int Importance { get; set; }
		public int Difficulty { get; set; }
		public double Score { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime EndDate { get; set; }
		public DateTime DeadLine { get; set; }
		public bool? Status { get; set; }
		public DateTime DateComplete { get; set; }
		public TaskType TaskType { get; set; }
		public int TaskTypeId { get; set; }
	}

	public class AdminOrgTasksVM
	{
		[Display(Name = "Total Number of Tasks")]
		public int TotalTasks { get; set; }
		[Display(Name = "Quadrant 1")]
		public int Q1Tasks { get; set; }
		[Display(Name = "Quadrant 2")]
		public int Q2Tasks { get; set; }
		[Display(Name = "Quadrant 3")]
		public int Q3Tasks { get; set; }
		[Display(Name = "Quadrant 4")]
		public int Q4Tasks { get; set; }
		public List<OrgTaskVM> OrgTasks { get; set; }
	}

	public class UpsertOrgTaskVM
	{
		public OrgTask OrgTask { get; set; }
		[Display(Name ="Task Name")]
		public string Name { get; set; }
		[Range(1,2)]
		public int Urgency { get; set; }
		[Range(1,2)]
		public int Importance { get; set; }
		[Range(1,4)]
		public int Difficulty { get; set; }
		[Display(Name ="Target End Date")]
		public DateTime EndDate { get; set; }
		[Display(Name ="Deadline")]
		public DateTime DeadLine { get; set; }
		public IEnumerable<SelectListItem> TaskTypes { get; set; }
		[Display(Name ="Task Type")]
		public int TaskTypeId { get; set; }

	}
}
