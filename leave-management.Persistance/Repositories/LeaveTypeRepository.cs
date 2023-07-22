using leave_management.Application.Contracts.Persistence;
using leave_management.Domain;
using leave_management.Persistance.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leave_management.Persistance.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(DBContextPg dBContext) : base(dBContext)
        {
        }

        public async Task<bool> IsLeaveTypeUniqye(string? name)
        {
            return await _dBContext.LeaveTypes.AnyAsync(x => x.Name == name);   
        }
    }
}
