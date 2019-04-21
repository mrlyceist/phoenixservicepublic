using LightInject;
using PhoenixService.ApiInfrastructure;
using PhoenixService.ScheduleApp.Actions;
using PhoenixService.ScheduleApp.Specifications.Actions;

namespace PhoenixService.ScheduleApi
{
    internal static class ServiceContainerExtension
    {
        internal static void RegisterTypes(this ServiceContainer container)
        {
            container.Register<IScheduleAction, ScheduleAction>();
            container.EnableAutoFactories();
            container.RegisterAutoFactory<IActionFactory>();
        }
    }
}