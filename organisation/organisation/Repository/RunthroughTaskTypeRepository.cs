using Microsoft.EntityFrameworkCore;
using organisation.Contracts;
using organisation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace organisation.Repository
{
	public class RunthroughTaskTypeRepository : IRunthroughTaskType
	{
		public readonly ApplicationDbContext _db;

		public RunthroughTaskTypeRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task<bool> Create(RunthroughTaskType entity)
		{
			await _db.RunthroughTaskTypes.AddAsync(entity);
			return await Save();
		}

		public async Task<bool> Delete(RunthroughTaskType entity)
		{
			_db.RunthroughTaskTypes.Remove(entity);
			return await Save();
		}

		public async Task<ICollection<RunthroughTaskType>> FindAll()
		{
			var rtTaskTypes = await _db.RunthroughTaskTypes.ToListAsync();
			return rtTaskTypes;
		}

		public async Task<RunthroughTaskType> FindById(int id)
		{
			var rtTaskType = await _db.RunthroughTaskTypes
				.FirstOrDefaultAsync(q=>q.Id==id);
			return rtTaskType;
		}

		public async Task<bool> isExists(int id)
		{
			var rtTaskStatus = await _db.RunthroughTaskTypes.AnyAsync(q=>q.Id==id);
			return rtTaskStatus;
		}

		public async Task<bool> Save()
		{
			var changes = await _db.SaveChangesAsync();
			return changes > 0;
		}

		public async Task<bool> Update(RunthroughTaskType entity)
		{
			_db.RunthroughTaskTypes.Update(entity);
			return await Save();
		}
	}
}
