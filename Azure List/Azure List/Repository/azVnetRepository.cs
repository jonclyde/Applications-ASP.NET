using Azure_List.Contracts;
using Azure_List.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure_List.Repository
{
	public class azVnetRepository : IAzVnetRepository
	{
		private readonly ApplicationDbContext _db;

		public azVnetRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task<bool> Create(azVnet entity)
		{
			await _db.azVnets.AddAsync(entity);
			return await Save();
		}

		public async Task<bool> Delete(azVnet entity)
		{
			_db.azVnets.Remove(entity);
			return await Save();
		}

		public async Task<ICollection<azVnet>> FindAll()
		{
			var azVnets = await _db.azVnets.ToListAsync();
			return azVnets;
		}

		public async Task<azVnet> FindById(int id)
		{
			var azVnet = await _db.azVnets
				.FirstOrDefaultAsync(q => q.Id == id);

			return azVnet;

		}

		public async Task<bool> isExists(int id)
		{
			var azVnet = await _db.azVnets.AnyAsync();
			return azVnet;

		}

		public async Task<bool> Save()
		{
			var changes = await _db.SaveChangesAsync();
			return changes > 0;
		}

		public async Task<bool> Update(azVnet entity)
		{
			_db.azVnets.Update(entity);
			return await Save();
		}
	}
}
