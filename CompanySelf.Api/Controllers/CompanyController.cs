using CompanySelf.Application.Companies.Commands.CreateCompany;
using CompanySelf.Application.Companies.Commands.DeleteCompany;
using CompanySelf.Application.Companies.Commands.UpdateCompany;
using CompanySelf.Application.Companies.Queries.SearchCompany;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CompanySelf.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[Action]")]
    public class CompanyController : Controller
    {
        private readonly IMediator _mediator;
        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateCompanyCommand command)
        {
            var commandResult = await _mediator.Send(command);            
            return Created("", commandResult.Result);
        }

        [Authorize]
        [HttpPut("{id}")]        
        public async Task<IActionResult> Update(long id, [FromBody] UpdateCompanyCommand command)
        {
            command.SetCompanyId(id);
            await _mediator.Send(command); 
            return Ok();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var command = new DeleteCompanyCommand(id);
            await _mediator.Send(command);         

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchCompanyQuery query)
        {
            var queryResult = await _mediator.Send(query);
            return Ok(queryResult.Result);
        }
    }
}
