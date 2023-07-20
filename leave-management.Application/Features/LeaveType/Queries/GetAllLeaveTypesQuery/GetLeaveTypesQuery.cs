using leave_management.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leave_management.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    /*public class GetLeaveTypesQuery : IRequest<List<LeaveTypeDto>>
    {
    }*/
    public record GetLeaveTypesQuery(int id) : IRequest<List<LeaveTypeDto>>;
}
