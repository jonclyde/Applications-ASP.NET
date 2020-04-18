using Microsoft.EntityFrameworkCore;
using organisation.Contracts;
using organisation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace organisation.Repository
{
	public class RunthroughTaskRepository : IRunthroughTask
	{
		public readonly ApplicationDbContext _db;

		public RunthroughTaskRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task<bool> Create(RunthroughTask entity)
		{
			await _db.RunthroughTask.AddAsync(entity);
			return await Save();
		}

		public async Task<bool> Delete(RunthroughTask entity)
		{
			_db.RunthroughTask.Remove(entity);
			return await Save();
		}

		public async Task<ICollection<RunthroughTask>> FindAll()
		{
			var rtTasks = await _db.RunthroughTask
				.OrderBy(q=>q.OrderNumber)
				.Include(q=>q.RTTaskSection)
				.Include(q=>q.RTTaskStatus)
				.Include(q=>q.RTTaskType)
				.ToListAsync();
			return rtTasks;
		}

		public async Task<RunthroughTask> FindById(int id)
		{
			var rtTask = await _db.RunthroughTask
				.Include(q => q.RTTaskSection)
				.Include(q => q.RTTaskStatus)
				.Include(q => q.RTTaskType)
				.FirstOrDefaultAsync(q => q.Id == id);
			return rtTask;
		}

		public async Task<int> GetNewOrderNumber()
		{
			var checkAny = await _db.RunthroughTask.AnyAsync();

			var newOrderNumber = 1;
			
			if(checkAny)
			{
				var lastRTTask = await _db.RunthroughTask
					.OrderByDescending(q => q.OrderNumber)
					.FirstAsync();

				newOrderNumber = lastRTTask.OrderNumber + 1;
			}

			return newOrderNumber;
		}

		public async Task<bool> isExists(int id)
		{
			var rtTask = await _db.RunthroughTask.AnyAsync(q => q.Id == id);
			return rtTask;
		}

		public Task<ICollection<RunthroughTask>> MoveDownOrder(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ICollection<RunthroughTask>> MoveUpOrder(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ICollection<RunthroughTask>> ReorderList(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> Save()
		{
			var changes = await _db.SaveChangesAsync();
			return changes > 0;
		}

		public async Task<bool> Update(RunthroughTask entity)
		{
			_db.RunthroughTask.Update(entity);
			return await Save();
		}
	}
}
