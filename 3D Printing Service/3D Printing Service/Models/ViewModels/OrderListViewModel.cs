using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3D_Printing_Service.Models.ViewModels
{
	public class OrderListViewModel
	{
		public IList<OrderDetailsViewModel> Orders { get; set; }
		public PagingInfo PagingInfo { get; set; }
	}
}
