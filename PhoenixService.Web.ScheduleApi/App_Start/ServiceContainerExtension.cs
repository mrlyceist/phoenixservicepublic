using LightInject;
using Microsoft.Extensions.Logging;
using PhoenixService.Data;
using PhoenixService.Data.Interfaces;
using PhoenixService.ScheduleApp;
using PhoenixService.Web.ScheduleApi.Configuration;
using Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace PhoenixService.Web.ScheduleApi
{
    internal static class ServiceContainerExtension
    {
        internal static void RegisterTypes(this ServiceContainer container)
        {
            container.Register<IDataConfiguration, Configuration.Configuration>();
            container.Register<IAppConfig, Configuration.Configuration>();
            container.Register<IApiConfig, Configuration.Configuration>();
            container.RegisterSingleton<ILogger>(factory => new LoggerFactory().AddSerilog().CreateLogger("category?"));
            container.RegisterAppDependencies();
            container.RegisterDataDependencies();
            container.EnableAutoFactories();
        }
    }
}