using AutoMapper;
using leave_management.Application.Contracts.Logger;
using leave_management.Application.Contracts.Persistence;
using leave_management.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leave_management.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetLeaveQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<GetLeaveQueryHandler> _logger;

        public GetLeaveQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository, IAppLogger<GetLeaveQueryHandler> logger)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _logger = logger;
        }
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _leaveTypeRepository.GetAsync();
            var data =_mapper.Map<List<LeaveTypeDto>>(leaveTypes);
            _logger.LogInformation("LEave types was retrieve successfolly");
            return data;
        }
    }
}
