using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace organisation.Data
{
	public class RunthroughHiscore
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public DateTime Date { get; set; }
		public int ResourceManual { get; set; }
		public int ResourceARMManual { get; set; }
		public int ResourceDevOpsv0_1 { get; set; }
		public int ResourceDevOpsv0_2 { get; set; }
		public int ResourceDevOpsTotal { get; set; }
		public int ResourceTotal { get; set; }
		public int TaskTotal { get; set; }
	}
}
