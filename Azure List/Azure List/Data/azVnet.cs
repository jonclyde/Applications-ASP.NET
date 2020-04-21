using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Azure_List.Data
{
	public class azVnet
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string resourceGroup { get; set; }
		public string location { get; set; }
		public string addressSpace { get; set; }
	}
}
