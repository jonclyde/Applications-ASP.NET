using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace organisation.Models
{
	public class OrgGoalVM
	{
		public int Id { get; set; }
		[Required]
		[Display(Name ="Goal Name")]
		public string Name { get; set; }
		public bool? Status { get; set; }
		[Display(Name ="Date Created")]
		public DateTime DateCreated { get; set; }

		[Display(Name ="Target Date")]
		public DateTime TargetDate { get; set; }
	}
}
