using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnethrmsmy.Application.CompanyStaffItems.Commands.CreateCompanyStaff;
using dotnethrmsmy.Application.CompanyStaffItems.Queries;
using MediatR;

namespace dotnethrmsmy.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyStaffController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CompanyStaffController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult<CompanyStaffVm>> GetAll()
        {
            return await _mediator.Send(new GetCompanyStaffQuery());


        }
        
        [HttpPost]
        
        public async Task<ActionResult<int>>Create(CreateCompanyStaffCommand command)
        {

            return await _mediator.Send(command);

        }
        
    }
}
