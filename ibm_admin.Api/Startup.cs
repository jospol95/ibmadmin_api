using ibm_admin.Business;
using ibm_admin.Contracts;
using ibm_admin.Dapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ibm_admin.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public string WebAppOrigin = "webapporigin";


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(jsonOptions =>
            {
                //Return Pascal Case
                jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            //Dapper
            services.AddSingleton<DapperContext>();
            //Media TR CQRS
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IMiembrosService, MiembrosService>();

            //Swagger
            services.AddSwaggerGen();

            //Cors
            services.AddCors(options =>
            {
                options.AddPolicy(WebAppOrigin,
                                      policy =>
                                      {
                                          policy.WithOrigins("https://icy-mud-02962fd0f.1.azurestaticapps.net/")
                                                              .AllowAnyHeader()
                                                              .AllowAnyMethod();
                                      });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();

                app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
                }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(WebAppOrigin);

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
