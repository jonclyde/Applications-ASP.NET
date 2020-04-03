using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskList.Models
{
	public class TaskCategory
	{
		[Key]
		public int Id { get; set; }

		[Display(Name="Task Category Name")]
		[Required]
		public string Name { get; set; }
	}
}
