using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using PhoenixService.Data.Interfaces;
using System.IO;

namespace PhoenixService.ScheduleApi.Configurations
{
    public class ConfigurationSettings : IDataConfiguration
    {
        private readonly IConfiguration configuration;

        public ConfigurationSettings(IHostingEnvironment env)
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public string PhoenixExecutablePath => configuration["PhoenixExecutablePath"];
    }
}