using leave_management.Application.Contracts.Persistence;
using leave_management.Domain;
using leave_management.Persistance.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace leave_management.Persistance.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(DBContextPg dBContext) : base(dBContext)
        {
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetail(int id)
        {
            var leaveRequest = await _dBContext.LeaveRequests
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);
            return leaveRequest ?? throw new ArgumentNullException(nameof(leaveRequest));
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetail()
        {
            var leaveRequest = await _dBContext.LeaveRequests
            .Include(q => q.LeaveType)
            .ToListAsync();
            return leaveRequest ?? throw new ArgumentNullException(nameof(leaveRequest));
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetail(string userId)
        {
            var leaveRequest = await _dBContext.LeaveRequests
                .Where(q => q.RequestingEmployeeId == userId)
                .Include(q => q.LeaveType)
                .ToListAsync();
            return leaveRequest ?? throw new ArgumentNullException(nameof(leaveRequest));
        }
    }
}
