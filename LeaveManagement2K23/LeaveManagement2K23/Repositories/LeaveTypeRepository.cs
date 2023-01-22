using LeaveManagement2K23.Contracts;
using LeaveManagement2K23.Data;

namespace LeaveManagement2K23.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
