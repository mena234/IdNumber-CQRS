using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Salary.API.Application.Queries;
using Salary.API.Application.Commands;

namespace Salary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ISalaryQueries _salaryQueries;

        public SalaryController(IMediator mediator, ISalaryQueries salaryQueries)
        {
            _mediator = mediator;
            _salaryQueries = salaryQueries;
        }   




        // GET api/values
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _salaryQueries.GetAllSalaryAsync();
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _salaryQueries.GetSalaryAsync(id);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);

        }


        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post(CreateSalaryCommand salaryCommand)
        {
            return Ok(await _mediator.Send(salaryCommand));
        }



        // PUT api/values/5
        [HttpPut]
        public async Task<ActionResult> PutAsync([FromBody] UpdateSalaryCommand salaryCommand)
        {
            return Ok(await _mediator.Send(salaryCommand));

        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(DeleteSalaryCommand salaryCommand)
        {
            return Ok(await _mediator.Send(salaryCommand));

        }
    }
}
