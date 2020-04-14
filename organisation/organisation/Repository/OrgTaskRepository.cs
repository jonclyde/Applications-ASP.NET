using Microsoft.EntityFrameworkCore;
using organisation.Contracts;
using organisation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace organisation.Repository
{
	public class OrgTaskRepository : IOrgTaskRepository
	{
		private readonly ApplicationDbContext _db;

		public OrgTaskRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task<bool> Create(OrgTask entity)
		{
			await _db.OrgTasks.AddAsync(entity);
			return await Save();

		}

		public async Task<bool> Delete(OrgTask entity)
		{
			_db.OrgTasks.Remove(entity);
			return await Save();
		}

		public async Task<ICollection<OrgTask>> FindAll()
		{
			var orgTasks = await _db.OrgTasks
				.ToListAsync();
			return orgTasks;
		}

		public async Task<OrgTask> FindById(int id)
		{
			var orgTasks = await _db.OrgTasks
				.FirstOrDefaultAsync(q => q.Id == id);
			return orgTasks;
		}

		public async Task<ICollection<OrgTask>> GetTasksByTaskType(int taskid)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> isExists(int id)
		{
			var exists = await _db.OrgTasks.AnyAsync(q => q.Id == id);
			return exists;
		}

		public async Task<bool> Save()
		{
			var changes = await _db.SaveChangesAsync();
			return changes > 0;
		}

		public async Task<bool> Update(OrgTask entity)
		{
			_db.OrgTasks.Update(entity);
			return await Save();
		}
	}
}
