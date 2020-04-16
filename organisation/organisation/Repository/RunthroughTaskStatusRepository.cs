using AutoMapper;
using Microsoft.EntityFrameworkCore;
using organisation.Contracts;
using organisation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace organisation.Repository
{
	public class RunthroughTaskStatusRepository : IRunthroughTaskStatus
	{
		private readonly ApplicationDbContext _db;

		public RunthroughTaskStatusRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task<bool> Create(RunthroughTaskStatus entity)
		{
			await _db.RunthroughTaskStatuses.AddAsync(entity);
			return await Save();
		}

		public async Task<bool> Delete(RunthroughTaskStatus entity)
		{
			_db.RunthroughTaskStatuses.Remove(entity);
			return await Save();
		}

		public async Task<ICollection<RunthroughTaskStatus>> FindAll()
		{
			var rtTaskStatuses = await _db.RunthroughTaskStatuses.ToListAsync();
			return rtTaskStatuses;
		}

		public async Task<RunthroughTaskStatus> FindById(int id)
		{
			var rtTaskStatus = await _db.RunthroughTaskStatuses
				.FirstOrDefaultAsync(q => q.Id == id);
			return rtTaskStatus;
		}

		public async Task<bool> isExists(int id)
		{
			var rtTaskStatus = await _db.RunthroughTaskStatuses
				.AnyAsync(q => q.Id == id);
			return rtTaskStatus;
		}

		public async Task<bool> Save()
		{
			var changes = await _db.SaveChangesAsync();
			return changes > 0;
		}

		public async Task<bool> Update(RunthroughTaskStatus entity)
		{
			_db.RunthroughTaskStatuses.Update(entity);
			return await Save();
		}
	}
}
