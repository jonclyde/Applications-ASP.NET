using Azure_List.Contracts;
using Azure_List.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure_List.Repository
{
	public class azVnetSubnetRepository : IAzVnetSubnetRepository
	{
		private readonly ApplicationDbContext _db;

		public azVnetSubnetRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task<bool> Create(azVnetSubnet entity)
		{
			await _db.azVnetSubnets.AddAsync(entity);
			return await Save();
		}

		public async Task<bool> Delete(azVnetSubnet entity)
		{
			_db.azVnetSubnets.Remove(entity);
			return await Save();
		}

		public async Task<ICollection<azVnetSubnet>> FindAll()
		{
			var azVnetSubnets = await _db.azVnetSubnets.ToListAsync();
			return azVnetSubnets;
		}

		public async Task<azVnetSubnet> FindById(int id)
		{
			var azVnetSubnet = await _db.azVnetSubnets
				.FirstOrDefaultAsync(q => q.Id == id);

			return azVnetSubnet;
		
		}

		public async Task<bool> isExists(int id)
		{
			var azVnet = await _db.azVnetSubnets.AnyAsync();
			return azVnet;

		}

		public async Task<bool> Save()
		{
			var changes = await _db.SaveChangesAsync();
			return changes > 0;
		}

		public async Task<bool> Update(azVnetSubnet entity)
		{
			_db.azVnetSubnets.Update(entity);
			return await Save();
		}
	}
}
