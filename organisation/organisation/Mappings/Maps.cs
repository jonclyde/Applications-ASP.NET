using AutoMapper;
using organisation.Data;
using organisation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace organisation.Mappings
{
	public class Maps : Profile
	{
		public Maps()
		{
			CreateMap<TaskType, TaskTypeVM>().ReverseMap();
			CreateMap<OrgTask, OrgTaskVM>().ReverseMap();
			CreateMap<OrgTask, UpsertOrgTaskVM>().ReverseMap();
		}
	}
}
