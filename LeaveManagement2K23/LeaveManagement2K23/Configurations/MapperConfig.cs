using AutoMapper;
using LeaveManagement2K23.Data;
using LeaveManagement2K23.Models;

namespace LeaveManagement2K23.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<LeaveType, LeaveTypeVM>().ReverseMap();
        }
    }
}
