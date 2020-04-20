using organisation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace organisation.Contracts
{
	public interface IRunthroughTask : IRepositoryBase<RunthroughTask>
	{
		Task<bool> MoveUpOrder(int currentOrderNumber);
		Task<bool> MoveDownOrder(int currentOrderNumber);
		Task<ICollection<RunthroughTask>> ReorderList(int id);
		Task<int> GetNewOrderNumber();
	}
}
