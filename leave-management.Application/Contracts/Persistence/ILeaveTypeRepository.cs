using leave_management.Domain;

namespace leave_management.Application.Contracts.Persistence
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
    {
        Task<bool> IsLeaveTypeUniqye(string? name);
    }
}
