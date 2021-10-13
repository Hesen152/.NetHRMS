using dotnethrmsmy.Application.CityItems;
using dotnethrmsmy.Application.CityItems.Queries;
using dotnethrmsmy.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnethrmsmy.Application.CityItems.Commands;

namespace dotnethrmsmy.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        

        public CitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<CityVm>> Get()
        {
            return await _mediator.Send(new GetCityQuery  ());
        }


        [HttpGet("{name}")]
        public async Task<ActionResult<CityVm>> GetByName(string name )
        {
            var vm=await _mediator.Send(new GetCitybyNameQuery { Name=name});

            return Ok(vm);
        }


        [HttpGet("{bynamencontains}")]
        public async Task<ActionResult<CityVm>>GetByNameContains(string name)
        {
            var vm = await _mediator.Send(new GetCitByNameContainQuery{ Name = name });

            return Ok(vm);


        }

        [HttpPost]
        public async Task<ActionResult<int>> Add(CreateCityCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
