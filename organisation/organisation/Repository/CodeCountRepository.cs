using Microsoft.EntityFrameworkCore;
using organisation.Contracts;
using organisation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace organisation.Repository
{
	public class CodeCountRepository : ICodeCountRepository
	{
		private readonly ApplicationDbContext _db;
		
		public CodeCountRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task<bool> Create(CodeCount entity)
		{
			await _db.CodeCounts.AddAsync(entity);
			return await Save();
		}

		public async Task<bool> Delete(CodeCount entity)
		{
			_db.CodeCounts.Remove(entity);
			return await Save();
		}

		public async Task<ICollection<CodeCount>> FindAll()
		{
			var codeCounts = await _db.CodeCounts.ToListAsync();
			return codeCounts;

		}

		public async Task<CodeCount> FindById(int id)
		{
			var codeCount = await _db.CodeCounts.FirstOrDefaultAsync(q => q.Id == id);
			return codeCount;
		}

		public async Task<CodeCount> GetLastCodeCountByDate()
		{
			var lastRTask = await _db.CodeCounts.OrderByDescending(q => q.Date)
				.FirstOrDefaultAsync();

			return lastRTask;
		}

		public async Task<bool> isExists(int id)
		{
			var codeCount = await _db.CodeCounts.AnyAsync(q => q.Id == id);
			return codeCount;
		}

		public async Task<bool> Save()
		{
			var changes = await _db.SaveChangesAsync();
			return changes > 0;
		}

		public async Task<bool> Update(CodeCount entity)
		{
			_db.CodeCounts.Update(entity);
			return await Save();
		}
	}
}
