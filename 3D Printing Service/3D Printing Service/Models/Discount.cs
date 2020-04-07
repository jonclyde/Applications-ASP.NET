using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _3D_Printing_Service.Models
{
	public class Discount
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
		public string DiscountType { get; set; }
		public enum EDiscountType { Percent = 0, Dollar = 1 }
		public double DiscountAmount { get; set; }
		public double MinimumAmount { get; set; }
		public byte[] Picture { get; set; }
		public bool isActive { get; set; }

	}
}
