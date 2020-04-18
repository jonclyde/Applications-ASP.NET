using Microsoft.AspNetCore.Mvc.Rendering;
using organisation.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace organisation.Models
{
	public class RunthroughTaskVM
	{
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
	public class AdminRunthroughTaskVM
	{
		public int TotalTasks { get; set; }
		public List<RunthroughTaskVM> RTTasks { get; set; }
	}

	public class CreateRunthroughTaskVM
	{
		public int Id { get; set; }
		public int OrderNumber { get; set; }
		public string Name { get; set; }

		public IEnumerable<SelectListItem> RTTaskSections { get; set; }

		public IEnumerable<SelectListItem> RTTaskStatuses { get; set; }

		public IEnumerable<SelectListItem> RTTaskTypes { get; set; }

		public int RTTaskSectionId { get; set; }
		public int RTTaskStatusId { get; set; }
		public int RTTaskTypeId { get; set; }
	}
}
