using Microsoft.EntityFrameworkCore;
using organisation.Contracts;
using organisation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace organisation.Repository
{
	public class OrgGoalRepository : IOrgGoalRepository
	{
		private readonly ApplicationDbContext _db;

		public OrgGoalRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task<bool> Create(OrgGoal entity)
		{
			await _db.OrgGoals.AddAsync(entity);
			return await Save();
		}

		public async Task<bool> Delete(OrgGoal entity)
		{
			_db.OrgGoals.Remove(entity);
			return await Save();
		}

		public async Task<ICollection<OrgGoal>> FindAll()
		{
			var orgGoals = await _db.OrgGoals
				.ToListAsync();
			return orgGoals;
		}

		public async Task<OrgGoal> FindById(int id)
		{
			var orgGoals = await _db.OrgGoals
				.FirstOrDefaultAsync(q => q.Id == id);
			return orgGoals;
		}

		public async Task<bool> isExists(int id)
		{
			var exists = await _db.OrgGoals.AnyAsync(q => q.Id == id);
			return exists;
		}

		public async Task<bool> Save()
		{
			var changes = await _db.SaveChangesAsync();
			return changes > 0;
		}

		public async Task<bool> Update(OrgGoal entity)
		{
			_db.OrgGoals.Update(entity);
			return await Save();
		}
	}
}
