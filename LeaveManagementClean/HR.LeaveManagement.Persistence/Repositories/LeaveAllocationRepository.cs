using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
        {
        }

        public async Task AddAllocation(List<LeaveAllocation> leaveAllocations)
        {
            await _context.AddRangeAsync(leaveAllocations);
        }

        public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
        {
            return await _context.LeaveAllocations
                .AnyAsync(q => q.EmployeeId == userId && q.LeaveTypeId == leaveTypeId && q.Period == period);
        }

        public Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var leaveAllocations = _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .ToListAsync();
            return leaveAllocations;
        }

        public Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
        {
            var leaveAllocations = _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .Where(q => q.EmployeeId == userId)
                .ToListAsync();
            return leaveAllocations;
        }

        public Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocation = _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);
            return leaveAllocation;
        }

        public Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
        {
            var leaveAllocation = _context.LeaveAllocations
                .FirstOrDefaultAsync(q => q.EmployeeId == userId && q.LeaveTypeId == leaveTypeId);
            return leaveAllocation;
        }
    }
}
