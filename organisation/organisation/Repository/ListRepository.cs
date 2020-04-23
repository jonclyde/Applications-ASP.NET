using Microsoft.EntityFrameworkCore;
using organisation.Contracts;
using organisation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace organisation.Repository
{
	public class ListRepository : IListRepository
	{
		private readonly ApplicationDbContext _db;

		public ListRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task<bool> Create(List entity)
		{
			await _db.Lists.AddAsync(entity);
			return await Save();

		}

		public async Task<bool> Delete(List entity)
		{
			_db.Lists.Remove(entity);
			return await Save();
		}

		public async Task<ICollection<List>> FindAll()
		{
			var lists = await _db.Lists.ToListAsync();
			return lists;
		}

		public async Task<List> FindById(int id)
		{
			var list = await _db.Lists.FirstOrDefaultAsync(q=>q.Id==id);
			return list;
		}

		public async Task<bool> isExists(int id)
		{
			var isExists = await _db.Lists.AnyAsync(q => q.Id == id);
			return isExists;
		}

		public async Task<bool> Save()
		{
			var changes = await _db.SaveChangesAsync();
			return changes > 0;
		}

		public async Task<bool> Update(List entity)
		{
			_db.Lists.Update(entity);
			return await Save();
		}
	}
}
