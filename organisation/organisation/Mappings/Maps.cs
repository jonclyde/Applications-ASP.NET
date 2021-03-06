﻿using AutoMapper;
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
			CreateMap<OrgTask, CreateOrgTaskVM>().ReverseMap();
			CreateMap<OrgTask, EditOrgTaskVM>().ReverseMap();
			CreateMap<OrgGoal, OrgGoalVM>().ReverseMap();
			CreateMap<RunthroughTaskSection, RunthroughTaskSectionVM>().ReverseMap();
			CreateMap<RunthroughTaskStatus, RunthroughTaskStatusVM>().ReverseMap();
			CreateMap<RunthroughTaskType, RunthroughTaskTypeVM>().ReverseMap();
			CreateMap<RunthroughHiscore, RunthroughHiscoreVM>().ReverseMap();
			CreateMap<CodeCount, CodeCountVM>().ReverseMap();
			CreateMap<RunthroughTask, RunthroughTaskVM>().ReverseMap();
			CreateMap<RunthroughTask, AdminRunthroughTaskVM>().ReverseMap();
			CreateMap<RunthroughTask, CreateRunthroughTaskVM>().ReverseMap();
			CreateMap<List, ListVM>().ReverseMap();
		}
	}
}
