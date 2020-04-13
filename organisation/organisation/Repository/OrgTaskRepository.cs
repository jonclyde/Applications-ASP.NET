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

		public Task<bool> Create(OrgTask entity)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Delete(OrgTask entity)
		{
			throw new NotImplementedException();
		}

		public Task<ICollection<OrgTask>> FindAll()
		{
			throw new NotImplementedException();
		}

		public Task<OrgTask> FindById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ICollection<OrgTask>> GetTasksByTaskType(int taskid)
		{
			throw new NotImplementedException();
		}

		public Task<bool> isExists(int id)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Save()
		{
			throw new NotImplementedException();
		}

		public Task<bool> Update(OrgTask entity)
		{
			throw new NotImplementedException();
		}
	}
}
