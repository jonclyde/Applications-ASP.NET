using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskList.Models.ViewModels
{
	public class TaskAndTaskCategoryViewModel
	{
		public IEnumerable<TaskCategory> TaskCategoryList { get; set; }
		public Tasks Tasks { get; set; }
		public List<string> TasksList { get; set; }
		public string StatusMessage { get; set; }
	
	}
}
