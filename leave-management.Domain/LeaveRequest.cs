using leave_management.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace leave_management.Domain
{
    public class LeaveRequest : BaseEntity
    {
        public DateTime? EndDate { get; set; }
        public DateTime? StartDate { get; set; }
        public LeaveType? LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime? DateRequested { get; set; }
        public string? RequestComments { get; set; }   
        public bool Aproved { get; set; }
        public bool Canceled { get; set; }
        public string? RequestingEmployeeId { get; set; }
    }
}
