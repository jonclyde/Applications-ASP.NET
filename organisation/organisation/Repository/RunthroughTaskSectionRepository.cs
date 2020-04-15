using Microsoft.EntityFrameworkCore;
using organisation.Contracts;
using organisation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace organisation.Repository
{
	public class RunthroughTaskSectionRepository : IRunthroughTaskSection
	{
		private readonly ApplicationDbContext _db;

		public RunthroughTaskSectionRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task<bool> Create(RunthroughTaskSection entity)
		{
			await _db.RunthroughTaskSections.AddAsync(entity);
			return await Save();
		}

		public async Task<bool> Delete(RunthroughTaskSection entity)
		{
			_db.RunthroughTaskSections.Remove(entity);
			return await Save();
		}

		public async Task<ICollection<RunthroughTaskSection>> FindAll()
		{
			var rtTaskSections = await _db.RunthroughTaskSections
				.ToListAsync();
			return rtTaskSections;
		}

		public async Task<RunthroughTaskSection> FindById(int id)
		{
			var rtTaskSections = await _db.RunthroughTaskSections.FirstOrDefaultAsync(q => q.Id == id);
			return rtTaskSections;
		}

		public async Task<bool> isExists(int id)
		{
			var exists = await _db.RunthroughTaskSections.AnyAsync(q => q.Id == id);
			return exists;
		}

		public async Task<bool> Save()
		{
			var changes = await _db.SaveChangesAsync();
			return changes > 0;
		}

		public async Task<bool> Update(RunthroughTaskSection entity)
		{
			_db.RunthroughTaskSections.Update(entity);
			return await Save();
		}
	}
}
