using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace organisation.Data
{
	public class OrgGoal
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Display(Name="Goal Status")]
		public bool? Status { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime TargetDate { get; set; }
	}
}
