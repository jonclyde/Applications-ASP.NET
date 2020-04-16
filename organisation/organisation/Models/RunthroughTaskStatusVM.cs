using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace organisation.Models
{
	public class RunthroughTaskStatusVM
	{
		public int Id { get; set; }
		[Required]
		[Display(Name="Task Status Name")]
		public string Name { get; set; }
		public DateTime DateCreated { get; set; }
	}
}
