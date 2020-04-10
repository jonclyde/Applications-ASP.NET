using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3D_Printing_Service.Models.ViewModels
{
	public class OrderDetailsCart
	{
		public List<ShoppingCart> listCart { get; set; }
		public OrderHeader OrderHeader { get; set; }
	}
}
