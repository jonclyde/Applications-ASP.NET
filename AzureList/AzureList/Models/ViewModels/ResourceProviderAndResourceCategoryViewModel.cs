using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureList.Models.ViewModels
{
	public class ResourceProviderAndResourceCategoryViewModel
	{
		public IEnumerable<ResourceCategory> ResourceCategoryList { get; set; }

		public ResourceProvider ResourceProvider { get; set; }

		public List<string> ResourceProviderList { get; set; }

		public string StatusMessage { get; set; }
	}
}
