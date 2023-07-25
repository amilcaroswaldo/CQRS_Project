using AutoMapper;
using leave_management.Application.Contracts.Logger;
using leave_management.Application.Contracts.Persistence;
using leave_management.Application.Exceptions;
using leave_management.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leave_management.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<CreateLeaveTypeHandler> _logger;

        public CreateLeaveTypeHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository, IAppLogger<CreateLeaveTypeHandler> logger)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _logger = logger;
        }

        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //validate data
            var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                _logger.LogWarnig("Validation errors in create request for {0} - {1}", nameof(LeaveType), request.Name);
                throw new BadRequestExceptions("Invalid leaveType", validationResult);
            }
            //convert to domain entity object
            var leaveTypeToCreate = _mapper.Map<Domain.LeaveType>(request);
            //add db
            await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);
            return leaveTypeToCreate.Id;
        }
    }
}
