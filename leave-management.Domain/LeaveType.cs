using leave_management.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leave_management.Domain
{
    public class LeaveType : BaseEntity
    {
        public string? Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
