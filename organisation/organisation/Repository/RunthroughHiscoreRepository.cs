using Microsoft.EntityFrameworkCore;
using organisation.Contracts;
using organisation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace organisation.Repository
{
	public class RunthroughHiscoreRepository : IRunthroughHiscore
	{
		public readonly ApplicationDbContext _db;

		public RunthroughHiscoreRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task<bool> Create(RunthroughHiscore entity)
		{
			await _db.RunthroughHiscores.AddAsync(entity);
			return await Save();
		}

		public async Task<bool> Delete(RunthroughHiscore entity)
		{
			_db.RunthroughHiscores.Remove(entity);
			return await Save();
		}

		public async Task<ICollection<RunthroughHiscore>> FindAll()
		{
			var rtHiscores = await _db.RunthroughHiscores.ToListAsync();
			return rtHiscores;
		}

		public async Task<RunthroughHiscore> FindById(int id)
		{
			var rtHiscore = await _db.RunthroughHiscores.FirstOrDefaultAsync(q => q.Id == id);
			return rtHiscore;
		}

		public async Task<bool> isExists(int id)
		{
			var rtHiscore = await _db.RunthroughHiscores.AnyAsync(q => q.Id == id);
			return rtHiscore;
		}

		public async Task<bool> Save()
		{
			var changes = await _db.SaveChangesAsync();
			return changes > 0;
		}

		public async Task<bool> Update(RunthroughHiscore entity)
		{
			_db.RunthroughHiscores.Update(entity);
			return await Save();
		}
	}
}
