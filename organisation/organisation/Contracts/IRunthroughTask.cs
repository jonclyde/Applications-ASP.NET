using organisation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace organisation.Contracts
{
	public interface IRunthroughTask : IRepositoryBase<RunthroughTask>
	{
		Task<ICollection<RunthroughTask>> MoveUpOrder(int id);
		Task<ICollection<RunthroughTask>> MoveDownOrder(int id);
		Task<ICollection<RunthroughTask>> ReorderList(int id);
		Task<int> GetNewOrderNumber();
	}
}
