using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AzureList.Models
{
	public class ResourceCategory
	{
		[Key]
		public int Id { get; set; }

		[Display(Name="Resource Category")]
		[Required]
		public string Name { get; set; }

	}
}
