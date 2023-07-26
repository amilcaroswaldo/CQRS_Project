using leave_management.Application.Features.LeaveType.Commands.CreateLeaveType;
using leave_management.Application.Features.LeaveType.Commands.DeleteLeaveType;
using leave_management.Application.Features.LeaveType.Commands.UpdateLeaveType;
using leave_management.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using leave_management.Application.Features.LeaveType.Queries.GetLeaveDetailsQuery;
using leave_management.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace leave_management.Api.Controlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<LeaveTypesController>
        [HttpGet("GetLeaveTypes")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<List<LeaveTypeDto>> GetLeaveTypes()
        {
            return await _mediator.Send(new GetLeaveTypesQuery());
        }

        // GET api/<LeaveTypesController>/5
        [HttpGet("FilterLeaveTypes")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<LeaveTypeDetailsDto> Get([FromQuery] int id)
        {
            return await _mediator.Send(new GetLeaveTypeDetailsQuery(id));
        }

        // POST api/<LeaveTypesController>
        [HttpPost("CreateLeaveTypes")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<int> Post([FromBody] CreateLeaveTypeCommand leaveType)
        {
            var res = await _mediator.Send(leaveType);
            //  return CreatedAtAction(nameof(Get), new { id = res });
            return res;
        }

        // PUT api/<LeaveTypesController>/5
        [HttpPut("UpdateLeaveTypes")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateLeaveTypes([FromBody] UpdateLeaveTypeCommand leaveType)
        {
            var res = await _mediator.Send(leaveType);
            return CreatedAtAction(nameof(Get), new { id = res });
        }

        // DELETE api/<LeaveTypesController>/5
        [HttpDelete("DeleteLeaveTypes")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete([FromQuery] DeleteLeaveTypeCommand deleteLeave)
        {
            await _mediator.Send(deleteLeave);
            return NoContent();
        }
    }
}
