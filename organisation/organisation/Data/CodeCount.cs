using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace organisation.Data
{
	public class CodeCount
	{
		[Key]
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public int IaC_Configurationv0_1 { get; set; }
		public int IaC_ARMv0_1 { get; set; }
		public int IaC_ARMv0_2 { get; set; }
		public int IaC_Terraformv0_1 { get; set; }
		public int Apps_ASP_NET { get; set; }
	}
}
