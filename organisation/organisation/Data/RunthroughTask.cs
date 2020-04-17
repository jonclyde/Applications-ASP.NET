using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace organisation.Data
{
	public class RunthroughTask
	{
		[Key]
		public int Id { get; set; }

		public int OrderNumber { get; set; }

		[Required]
		public string Name { get; set; }
		public RunthroughTaskSection RTTaskSection { get; set; }
		public RunthroughTaskStatus RTTaskStatus { get; set; }
		public RunthroughTaskType RTTaskType { get; set; }

		public int RTTaskSectionId { get; set; }
		public int RTTaskStatusId { get; set; }
		public int RTTaskTypeId { get; set; }

	}
}
