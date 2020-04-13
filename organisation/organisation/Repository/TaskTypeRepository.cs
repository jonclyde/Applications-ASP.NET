using Microsoft.EntityFrameworkCore;
using organisation.Contracts;
using organisation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace organisation.Repository
{
	public class TaskTypeRepository : ITaskTypeRepository
	{
		private readonly ApplicationDbContext _db;

		public TaskTypeRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task<bool> Create(TaskType entity)
		{
			await _db.TaskTypes.AddAsync(entity);
			return await Save();
		}

		public async Task<bool> Delete(TaskType entity)
		{
			_db.TaskTypes.Remove(entity);
			return await Save();
		}

		public async Task<ICollection<TaskType>> FindAll()
		{
			var taskTypes = await _db.TaskTypes.ToListAsync();
			return taskTypes;
		}

		public async Task<TaskType> FindById(int id)
		{
			var taskType = await _db.TaskTypes.FindAsync(id);
			return taskType;
		}

		public async Task<bool> isExists(int id)
		{
			var exists = await _db.TaskTypes.AnyAsync(q => q.Id == id);
			return exists;
		}

		public async Task<bool> Save()
		{
			var changes = await _db.SaveChangesAsync();
			return changes > 0;
		}

		public async Task<bool> Update(TaskType entity)
		{
			_db.TaskTypes.Update(entity);
			return await Save();
		}
	}
}
