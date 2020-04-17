using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace organisation.Models
{
	public class CodeCountVM
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		[Display(Name = "Configuration v0.1 Characters")]
		public int IaC_Configurationv0_1 { get; set; }
		[Display(Name = "ARM v0.1 Characters")]
		public int IaC_ARMv0_1 { get; set; }
		[Display(Name = "ARM v0.2 Characters")]
		public int IaC_ARMv0_2 { get; set; }
		[Display(Name = "Terraform v0.1 Characters")]
		public int IaC_Terraformv0_1 { get; set; }
		[Display(Name = "ASP.NET Applications")]
		public int Apps_ASP_NET { get; set; }
	}
}
