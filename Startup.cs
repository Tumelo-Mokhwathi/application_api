using application_api.Configurations;
using application_api.DataAccess;
using application_api.Models;
using application_api.Services.Implementations;
using application_api.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace application_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public const string specificOriginKey = "12345";
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddCors(option =>
            {
                var corsOpts = Configuration.GetSection("Cors").Get<CorsOptions>();
                option.AddPolicy(specificOriginKey,
                    builder => builder.AllowAnyMethod()
                                      .AllowAnyHeader()
                                      .WithOrigins(corsOpts.GetAllowedOriginsAsArray()));
            });
            services.AddTransient<ICoursesService, CoursesService>();
            services.AddTransient<IDelegateService, DelegateService>();
            services.AddTransient<ITrainingsService, TrainingsService>();

            //SQL Serverservices.AddTransient<IUserService, CoursesService>();
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("SQLDatabase")));
            //You can use in memory database
            //services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("NoSQLDatabase"));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Application API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(specificOriginKey);
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
