using LightInject;
using PhoenixService.Data.Interfaces;
using PhoenixService.ScheduleApp.Actions;
using PhoenixService.ScheduleApp.Builders;
using PhoenixService.ScheduleApp.Services;
using PhoenixService.ScheduleApp.Specifications.Actions;
using PhoenixService.ScheduleApp.Specifications.Builders;
using PhoenixService.ScheduleApp.Specifications.Services;

namespace PhoenixService.ScheduleApp
{
    public static class ServiceContainerExtension
    {
        public static void RegisterAppDependencies(this ServiceContainer container)
        {
            // Actions
            container.Register<IScheduleAction, ScheduleAction>();
            container.Register<IAppointmentsAction, AppointmentsAction>();
            container.Register<ITestAction, TestAction>();
            // Builders
            container.Register<IAvailableAppointmentsMBuilder, AvailableAppointmentsMBuilder>();
            container.Register<ISpecialistWithScheduleMBuilder, SpecialistWithScheduleMBuilder>();
            // Services
            container.Register<IAppointmentsService, AppointmentsService>();
            container.Register<IVoiceServiceTaskService, VoiceServiceTaskService>();
        }
    }
}