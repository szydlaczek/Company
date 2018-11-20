using CompanySelf.Infrastructure.CommandQuery.Bus;
using CompanySelf.Infrastructure.CommandQuery.Commands;
using CompanySelf.Infrastructure.CommandQuery.Queries;
using CompanySelf.Infrastructure.Dtos;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CompanySelf.Api.Controllers
{
    public class CompanyController : ApiController
    {
        protected readonly ICommandsBus CommandBus;  //przyjmuje komendy np do wstawienia do bazy
        protected readonly IQueryBus QueryBus; // query to zapytania np lista rekordów

        public CompanyController(ICommandsBus commandBus, IQueryBus queryBus)
        {
            CommandBus = commandBus;
            QueryBus = queryBus;
        }

        [HttpPost]
        [Authorize]
        public async Task<IHttpActionResult> Create([FromBody] CompanyDto createCompany)
        {
            var result = await CommandBus.Send(new CreateCompanyCommand { Company = createCompany });
            return Created($"company/{result.Data.ToString()}", new { Id = result.Data });
        }

        [HttpPut]
        [Authorize]
        public async Task<IHttpActionResult> Update(long id, [FromBody] CompanyDto updateCompany)
        {
            var result = await CommandBus.Send(new UpdateCompanyCommand { Company = updateCompany, CompanyId = id });
            if (result.Succeeded == false)
            {
                return ResponseMessage(GetResponseMessage(HttpStatusCode.NotFound, result.Message));
            }
            else
                return Ok();
        }

        [HttpDelete]
        [Authorize]
        public async Task<IHttpActionResult> Delete(long Id)
        {
            var result = await CommandBus.Send(new DeleteCompanyCommand { CompanyId = Id });
            if (result.Succeeded == false)
            {
                return ResponseMessage(GetResponseMessage(HttpStatusCode.NotFound, result.Message));
            }
            else
                return Ok();
        }

        [HttpPost]
        public async Task<IHttpActionResult> Search(SearchCriteria criteria)
        {
            var result = await QueryBus.Send(new SearchCompanyQuery { SearchCriteria = criteria });
            return Ok(result.Data);
        }

        private HttpResponseMessage GetResponseMessage(HttpStatusCode statusCode, string Message)
        {
            var response = new HttpResponseMessage(statusCode);
            var message = new
            {
                error = Message
            };
            response.Content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
            return response;
        }
    }
}