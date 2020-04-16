using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace organisation.Models
{
	public class RunthroughHiscoreVM
	{
		public int Id { get; set; }

		[Required]
		[Display(Name ="Date of runthrough")]
		public DateTime Date { get; set; }

		[Display(Name ="Manual Resources")]
		public int ResourceManual { get; set; }

		[Display(Name = "Manual ARM Resources")]
		public int ResourceARMManual { get; set; }

		[Display(Name = "ARM DevOps v0.1")]
		public int ResourceDevOpsv0_1 { get; set; }

		[Display(Name = "ARM DevOps v0.2")]
		public int ResourceDevOpsv0_2 { get; set; }

		[Display(Name = "ARM DevOps Total")]
		public int ResourceDevOpsTotal { get; set; }

		[Display(Name = "Total Resources")]
		public int ResourceTotal { get; set; }

		[Display(Name = "Total Tasks")]
		public int TaskTotal { get; set; }
	}
}
