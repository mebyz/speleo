using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.Swagger.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using System.IO;
using System.Reflection;

namespace Speleo
{
    /// <summary>
    /// todo
    /// </summary>
    /// <remarks>todo</remarks>     
    public class Startup
    {
        /// <summary>
        /// todo
        /// </summary>
        /// <remarks>todo</remarks>     
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }
            
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        /// <summary>
        /// todo
        /// </summary>
        /// <remarks>todo</remarks>     
        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        /// <summary>
        /// todo
        /// </summary>
        /// <remarks>todo</remarks>     
        public void ConfigureServices(IServiceCollection services)
        {

            // Add framework services.
            var xmlSwaggerPath = GetXmlCommentsPath();

            //Enable Cors
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddMvc();
            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "Speleo",
                    Description = "Speleo API (using .Net Core 2 Web API - Docker - Rancher)",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Emmanuel BOTROS YOUSSEF", Email = "e.botros@lekiosk.com", Url = "www.lekiosk.com" }
                });
                options.IncludeXmlComments(xmlSwaggerPath);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        /// <summary>
        /// todo
        /// </summary>
        /// <remarks>todo</remarks>     
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors("CorsPolicy");

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUi();
        }

        private string GetXmlCommentsPath()
        {
            return System.IO.Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Speleo.xml");
        }
    }
}
