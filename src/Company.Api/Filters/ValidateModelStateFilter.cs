using CompanySelf.Infrastructure.Validation;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CompanySelf.Api.Filters
{
    public class ValidateModelStateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                
                ErrorResponse responsePack = new ErrorResponse();

                var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                foreach (var modelState in actionContext.ModelState.Values)
                {
                    foreach (var modelError in modelState.Errors)
                    {
                        responsePack.Errors.Add(modelError.ErrorMessage);
                    }
                }
                response.Content = new StringContent(JsonConvert.SerializeObject(responsePack), Encoding.UTF8, "application/json");

                actionContext.Response = response;
            }
        }
    }
}