using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task.Application.Feature.SalaryCalculation.Requests.Commands;
using Task.Application.Feature.SalaryCalculation.Requests.Queries;
using Task.Shared.DTOs.SalaryCalculation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task.Api.Controllers
{
    [Route("api/{datatype}/[controller]")]
    [ApiController]
    public class SalaryCalculationController : ControllerBase
    {
        public readonly IMediator _mediator;

        public SalaryCalculationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<SalaryCalculationController>
        [HttpGet("GetSalaryCalculation/{fromDate}/{toDate}")]
        public async Task<ActionResult<List<SalaryCalculationDto>>> GetRange([FromRoute] string datatype, string fromDate, string toDate)
        {
            var response = await _mediator.Send(new GetRengeSalaryCalculationQueryRequest { Datatype = datatype, FromDate = fromDate, ToDate = toDate });
            return Ok(response);
        }

        // GET api/<SalaryCalculationController>/5
        [HttpGet("GetSalaryCalculation/{id}")]
        public async Task<ActionResult<SalaryCalculationDto>> Get([FromRoute] string datatype, int id)
        {
            var response = await _mediator.Send(new GetSalaryCalculationQueryRequest { Datatype = datatype, Id = id });
            return Ok(response);
        }

        // POST api/<SalaryCalculationController>
        [HttpPost("CreateSalaryCalculation")]
        public async Task<ActionResult<SalaryCalculationDto>> Add([FromRoute] string datatype, [FromBody] SalaryCalculationRawRequest request)
        {
            var command = new CreateSalaryCalculationCommandRequest { Datatype = datatype, Data = request.Data, OverTimeCalculator = request.OverTimeCalculator };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<SalaryCalculationController>/5
        [HttpPut("UpdateSalaryCalculation/{id}")]
        public async Task<ActionResult<SalaryCalculationDto>> Update([FromRoute] string datatype, int id, [FromBody] SalaryCalculationRawRequest request)
        {
            var command = new UpdateSalaryCalculationCommandRequest { Datatype = datatype, Id = id, Data = request.Data, OverTimeCalculator = request.OverTimeCalculator };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // DELETE api/<SalaryCalculationController>/5
        [HttpDelete("DeleteSalaryCalculation/{id}")]
        public async Task<ActionResult<SalaryCalculationDto>> Delete([FromRoute] string datatype, int id)
        {
            var command = new DeleteSalaryCalculationCommandRequest { Datatype = datatype, Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
