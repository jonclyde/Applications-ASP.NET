using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3D_Printing_Service.Models.ViewModels
{
	public class IndexViewModel
	{
		public IEnumerable<Product> Product { get; set; }
		public IEnumerable<Category> Category { get; set; }
		public IEnumerable<Discount> Discount { get; set; }
	}
}
