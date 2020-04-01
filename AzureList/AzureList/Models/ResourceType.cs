using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AzureList.Models
{
	public class ResourceType
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Display(Name = "Resource Category")]
		public int ResourceCategoryId { get; set; }

		[ForeignKey("ResourceCategoryId")]
		public virtual ResourceCategory ResourceCategory { get; set; }

		[Display(Name = "Resource Provider")]
		public int ResourceProviderId { get; set; }

		[ForeignKey("ResourceProviderId")]
		public virtual ResourceProvider ResourceProvider { get; set; }

	}
}
