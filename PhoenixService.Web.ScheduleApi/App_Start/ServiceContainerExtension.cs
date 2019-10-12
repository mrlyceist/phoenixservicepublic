using LightInject;
using PhoenixService.Data;
using PhoenixService.Data.Interfaces;
using PhoenixService.ScheduleApp;

namespace PhoenixService.Web.ScheduleApi
{
    internal static class ServiceContainerExtension
    {
        internal static void RegisterTypes(this ServiceContainer container)
        {
            container.Register<IDataConfiguration, Configuration>();
            container.Register<IAppConfig, Configuration>();
            container.RegisterAppDependencies();
            container.RegisterDataDependencies();
            container.EnableAutoFactories();
        }
    }
}