using leave_management.Application.Contracts.Persistence;
using leave_management.Domain;
using leave_management.Persistance.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace leave_management.Persistance.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(DBContextPg dBContext) : base(dBContext)
        {
        }

        public async Task AddAllocation(List<LeaveAllocation> allocation)
        {
            await _dBContext.AddRangeAsync(allocation);
            //await _dBContext.SaveChangesAsync();
        }

        public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
        {
            return await _dBContext.LeaveAllocation.AnyAsync(q =>
            q.EmployeeId == userId
            && q.LeaveTypeId == leaveTypeId
            && q.Period == period);
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocations = await _dBContext.LeaveAllocation
            .Include(q => q.LeaveType)
            .FirstOrDefaultAsync(q => q.Id == id);
            return leaveAllocations ?? throw new ArgumentNullException(nameof(leaveAllocations));
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
        {
            var leaveAllocations = await _dBContext.LeaveAllocation
                .Include(q => q.LeaveType)
                .ToListAsync();
            return leaveAllocations ?? throw new ArgumentNullException(nameof(leaveAllocations));
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId)
        {
            var leaveAllocations = await _dBContext.LeaveAllocation.Where(q => q.EmployeeId == userId)
                .Include(q => q.LeaveType)
                .ToListAsync();
            return leaveAllocations ?? throw new ArgumentNullException(nameof(leaveAllocations));
        }

        public async Task<LeaveAllocation> GetUserAllocation(string userId, int leaveTipeId)
        {
            var getUserAllocations = await _dBContext.LeaveAllocation
                .FirstOrDefaultAsync(q => q.EmployeeId == userId && q.LeaveTypeId == leaveTipeId);
            return getUserAllocations ?? throw new ArgumentNullException( nameof(getUserAllocations));
        }
    }
}
