using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Questys.RestfullAPI.Shared.ServiceHelper.Common.Helpers;

namespace Questys.RestfullAPI.Repository.Api
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
            services.AddApplication<RepositoryHttpApiHostModule>();

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(o =>
            //{
            //    o.Authority = Configuration["Jwt:Authority"];
            //    o.Audience = Configuration["Jwt:Audience"];
            //    o.RequireHttpsMetadata = Convert.ToBoolean(Configuration["Jwt:RequireHttpsMetadata"]);
            //    o.Events = new JwtBearerEvents()
            //    {
            //        OnAuthenticationFailed = c =>
            //        {
            //            c.NoResult();

            //            c.Response.StatusCode = 500;
            //            c.Response.ContentType = "text/plain";
            //            //TODO: Log exception to log, and return message over API
            //            //if (Environment.IsDevelopment())
            //            //{
            //            return c.Response.WriteAsync(c.Exception.ToString());
            //            //}
            //            //return c.Response.WriteAsync("An error occured processing your authentication.");
            //        }
            //    };
            //});

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("RepositoryAccess",
            //        policy => policy.AddRequirements(new KeycloakRoleRequirement("module-Repositories")));
            //});

            //services.AddSingleton<IAuthorizationHandler, KeycloakRoleAuthorizationHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
