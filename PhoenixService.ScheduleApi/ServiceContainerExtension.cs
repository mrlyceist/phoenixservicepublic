using LightInject;
using PhoenixService.ApiInfrastructure;
using PhoenixService.Data;
using PhoenixService.Data.Interfaces;
using PhoenixService.ScheduleApi.Configurations;
using PhoenixService.ScheduleApp.Actions;
using PhoenixService.ScheduleApp.Builders;
using PhoenixService.ScheduleApp.Services;
using PhoenixService.ScheduleApp.Specifications.Actions;
using PhoenixService.ScheduleApp.Specifications.Builders;
using PhoenixService.ScheduleApp.Specifications.Services;
using System.Data.OleDb;

namespace PhoenixService.ScheduleApi
{
    internal static class ServiceContainerExtension
    {
        internal static void RegisterTypes(this ServiceContainer container)
        {
            //var ole = new OleDbConnection();

            container.Register<IScheduleAction, ScheduleAction>();
            container.Register<IAppointmentsAction, AppointmentsAction>();
            container.Register<IAvailableAppointmentsMBuilder, AvailableAppointmentsMBuilder>();
            container.Register<ISpecialistWithScheduleMBuilder, SpecialistWithScheduleMBuilder>();
            container.Register<IAppointmentsService, AppointmentsService>();
            container.Register<IDataConfiguration, ConfigurationSettings>();
            container.RegisterDataDependencies();
            container.EnableAutoFactories();
            container.RegisterAutoFactory<IActionFactory>();
        }
    }
}