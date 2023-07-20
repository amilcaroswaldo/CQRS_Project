using leave_management.Domain.Common;

namespace leave_management.Domain
{
    public class LeaveAllocation : BaseEntity
    {
        public string? Name { get; set; }
        public int NumberOfDays { get; set; }
        public LeaveType? LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; } 
    }
}
