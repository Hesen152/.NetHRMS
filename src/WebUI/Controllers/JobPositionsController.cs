using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnethrmsmy.Application.JobPositionsItem.Commands.CreateJobPositions;
using dotnethrmsmy.Application.JobPositionsItem.Commands.DeleteJobPositions;
using dotnethrmsmy.Application.JobPositionsItem.Queries.GetTodos;
using dotnethrmsmy.Application.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Namotion.Reflection;

namespace dotnethrmsmy.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPositionsController : ControllerBase
    {

        private IMediator _mediator;

        public JobPositionsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        
        public async  Task<ActionResult<int>> Add(CreateJobPositionsCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete]

        public async Task<IActionResult> Delete(int id)
        {
             await _mediator.Send(new DeleteJobPositionsCommands{Id = id});

             return NoContent();
        }

        [HttpGet]

        public async  Task<IDataResult<JobPositionsVm>> GetAll()
        {
            return await _mediator.Send(new GetJobPositionsQuery());
        }

    }
}