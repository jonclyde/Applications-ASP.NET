using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureList.Models.ViewModels
{
	public class ResourceTypeViewModel
	{
		public ResourceType ResourceType { get; set; }

		public IEnumerable<ResourceCategory> ResourceCategory { get; set; }
		
		public IEnumerable<ResourceProvider> ResourceProvider { get; set; }
	}
}
