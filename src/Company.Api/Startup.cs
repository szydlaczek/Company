using Autofac;
using Autofac.Integration.WebApi;
using CompanySelf.Api.Filters;
using CompanySelf.Infrastructure.Identity;
using CompanySelf.Infrastructure.IOC;
using FluentValidation.WebApi;
using Owin;
using System.Reflection;
using System.Web.Http;
using Thinktecture.IdentityModel.Owin;

namespace CompanySelf.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            appBuilder.UseBasicAuthentication(new BasicAuthenticationOptions("SecureApi",
                  (username, password) => SignInManager.Authenticate(username, password)));

            config.Routes.MapHttpRoute(
              name: "DefaultApi",
              routeTemplate: "{controller}/{action}/{id}",
              defaults: new { id = RouteParameter.Optional }
          );
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            config.Filters.Add(new ValidateModelStateFilter());
            builder.RegisterModule(new ContainerModule());
            builder.RegisterWebApiFilterProvider(config);
            FluentValidationModelValidatorProvider.Configure(config);
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            appBuilder.UseAutofacMiddleware(container);
            appBuilder.UseAutofacWebApi(config);
            appBuilder.UseWebApi(config);
        }
    }
}