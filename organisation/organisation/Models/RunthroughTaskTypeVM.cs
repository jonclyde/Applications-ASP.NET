﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace organisation.Models
{
	public class RunthroughTaskTypeVM
	{
		public int Id { get; set; }
		[Required]
		[Display(Name="Task Type Name")]
		public string Name { get; set; }
		[Display(Name="Date Created")]
		public DateTime DateCreated { get; set; }
	}
}
