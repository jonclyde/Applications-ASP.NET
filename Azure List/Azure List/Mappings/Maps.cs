using AutoMapper;
using Azure_List.Data;
using Azure_List.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure_List.Mappings
{
	public class Maps : Profile
	{
		public Maps()
		{
			CreateMap<azVnet, AzVnetVM>().ReverseMap();
		}
	}
}
