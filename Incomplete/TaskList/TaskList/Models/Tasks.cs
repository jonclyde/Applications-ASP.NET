using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskList.Models
{
	public class Tasks
	{
		[Key]
		public int Id { get; set; }

		[Display(Name="Task Name")]
		[Required]
		public string Name { get; set; }

		public int Urgency { get; set; }

		public int Difficulty { get; set; }

		[Required]
		[Display(Name="Task Category")]
		public int TaskCategoryId { get; set; }

		[ForeignKey("TaskCategoryId")]
		public virtual TaskCategory TaskCategory { get; set; }
	}
}
