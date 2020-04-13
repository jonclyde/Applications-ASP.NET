using organisation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace organisation.Contracts
{
	public interface IOrgTaskRepository : IRepositoryBase<OrgTask>
	{
		Task<ICollection<OrgTask>> GetTasksByTaskType(int taskid);
	}
}
