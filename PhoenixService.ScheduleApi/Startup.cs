using LightInject;
using LightInject.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoenixService.ApiInfrastructure.Extensions;
using PhoenixService.ScheduleApi.Configurations;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;
using PhoenixService.ApiInfrastructure;

namespace PhoenixService.ScheduleApi
{
    public class Startup
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var config = new ConfigurationSettings(hostingEnvironment);
            var containerOptions = new ContainerOptions { EnablePropertyInjection = false };
            var serviceContainer = new ServiceContainer(containerOptions)
            {
                ScopeManagerProvider = new PerLogicalCallContextScopeManagerProvider()
            };

            serviceContainer.RegisterServices(
                services
                    .AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddControllersAsServices()
                    .Services
                    .AddSwaggerGen(c =>
                    {
                        c.SwaggerDoc("v1", new Info {Title = hostingEnvironment.ApplicationName});
                        var dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                        foreach (var file in dir.EnumerateFiles("*.xml"))
                            c.IncludeXmlComments(file.FullName);
                    }));

            serviceContainer.RegisterTypes();
            serviceContainer.EnableAutoFactories();
            serviceContainer.RegisterAutoFactory<IActionFactory>();

            var serviceProvider = serviceContainer.CreateServiceProvider(services);
            return serviceProvider;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMvc()
                .UseHttpsRedirection()
                .UseSwagger()
                .UseSwaggerUI(options =>
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", hostingEnvironment.ApplicationName));
        }
    }
}
