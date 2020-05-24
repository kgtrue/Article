using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Articles.Core.Application;
using Articles.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using FluentValidation.AspNetCore;
using Articles.Core.Application.Common.Interfaces;

namespace Articles.API
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
            services.AddPersistence(Configuration);
            services.AddApplication();
            services.AddControllers();
            services.AddSwaggerDocument(configure =>
            {
                configure.Title = "Articles API";
            });
            //services.AddOpenApiDocument(configure =>
            //{
            //    configure.Title = "Articles API";
            //});
            services
               .AddControllersWithViews()
               .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IArticleDbContext>());

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
           
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
            app.UseOpenApi();
            app.UseSwaggerUi3(settings =>
            {
                settings.Path = "/api";
            });
        }
    }
}
