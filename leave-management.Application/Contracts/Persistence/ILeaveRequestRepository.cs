using leave_management.Domain;

namespace leave_management.Application.Contracts.Persistence
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetail(int id);
        Task<List<LeaveRequest>> GetLeaveRequestWithDetail();
        Task<List<LeaveRequest>> GetLeaveRequestWithDetail(string userId);
    }
}
