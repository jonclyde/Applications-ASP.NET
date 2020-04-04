using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AzureList.Models
{
	public class ResourceProvider
	{
        [Key]
        public int Id { get; set; }

        [Display(Name = "Resource Provider Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Resource Category")]
        [Required]
        public int ResourceCategoryId { get; set; }

        [ForeignKey("ResourceCategoryId")]
        public virtual ResourceCategory ResourceCategory { get; set; }

    }
}
