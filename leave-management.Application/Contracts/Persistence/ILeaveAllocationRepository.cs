using leave_management.Domain;

namespace leave_management.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
        Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails();
        Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId);
        Task<bool> AllocationExists(string userId, int leaveTypeId, int period);
        Task AddAllocation(List<LeaveAllocation> allocation);
        Task<LeaveAllocation> GetUserAllocation(string userId, int leaveTipeId);

    }
}
