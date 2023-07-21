using AutoMapper;
using leave_management.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using leave_management.Application.Features.LeaveType.Queries.GetLeaveDetailsQuery;
using leave_management.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leave_management.Application.MappingProfiles
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetailsDto>();
        }
    }
}
