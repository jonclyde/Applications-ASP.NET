using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Azure_List.Data
{
	public class azVnetSubnet
	{
		[Key]
		public int Id { get; set; }
		public string name { get; set; }
		public string addressRange { get; set; }
		public string securityGroup { get; set; }
		public string routeTable { get; set; }
	}
}
