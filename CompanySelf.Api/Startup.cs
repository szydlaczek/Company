using CompanySelf.Api.Core;
using CompanySelf.Application.Companies.Commands.CreateCompany;
using CompanySelf.Application.Services;
using CompanySelf.Persistence;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CompanySelf.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = false;
            });

            services.AddScoped<IUserService, UserService>();
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
            services.AddMediatR(typeof(CreateCompanyCommandHandler).GetTypeInfo().Assembly);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateCompanyCommandValidator>());
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseApiException();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}