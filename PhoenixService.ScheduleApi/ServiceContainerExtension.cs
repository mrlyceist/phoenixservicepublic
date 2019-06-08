using LightInject;
using NCore;
using NCore.Factories;
using NCore.Models;
using NCore.Services;
using NCore.Specifications;
using NCore.Specifications.Factories;
using NCore.Specifications.Services;
using PhoenixService.ApiInfrastructure;
using PhoenixService.Data.Factories;
using PhoenixService.Data.Interfaces;
using PhoenixService.Data.Interfaces.Factories;
using PhoenixService.Data.Interfaces.Resolvers;
using PhoenixService.Data.Resolvers;
using PhoenixService.ScheduleApi.Configurations;
using PhoenixService.ScheduleApp.Actions;
using PhoenixService.ScheduleApp.Builders;
using PhoenixService.ScheduleApp.Services;
using PhoenixService.ScheduleApp.Specifications.Actions;
using PhoenixService.ScheduleApp.Specifications.Builders;
using PhoenixService.ScheduleApp.Specifications.Services;

namespace PhoenixService.ScheduleApi
{
    internal static class ServiceContainerExtension
    {
        internal static void RegisterTypes(this ServiceContainer container)
        {
            container.Register<IScheduleAction, ScheduleAction>();
            container.Register<IAppointmentsAction, AppointmentsAction>();
            container.Register<IAvailableAppointmentsMBuilder, AvailableAppointmentsMBuilder>();
            container.Register<ISpecialistWithScheduleMBuilder, SpecialistWithScheduleMBuilder>();
            container.Register<IAppointmentsService, AppointmentsService>();
            container.Register<IAppointmentFactory, AppointmentFactory>();
            container.Register<ISpecialistFactory, SpecialistFactory>();
            container.Register<IAppointmentsResolver, AppointmentsResolver>();
            container.Register<ISpecialistResolver, SpecialistResolver>();
            container.Register<IDataConfiguration, ConfigurationSettings>();
            container.Register<IFoxDbInteractor, FoxDbInteractor>(new PerContainerLifetime());
            container.Register<IEntityFactory<Employee>, EmployeeFactory>();
            container.Register<ICategoryTransform, CategoryTransform>();
            container.Register<IEntityFactory<Kdg>, KdgFactory>();
            container.Register<IEntityFactory<Duty>, DutyFactory>();
            container.Register<IEntityFactory<Patient>, PatientFactory>();
            container.Register<IEntityFactory<Department>, DepartmentFactory>();
            container.Register<IPhoenixSetupService, PhoenixSetupService>();
            container.Register<IEntityFactory<Specialty>, SpecialtyFactory>();
            container.Register<IIVoiceDuty, IVoiceDuty>();
            container.Register<IScheduleService, ScheduleService>();
            container.EnableAutoFactories();
            container.RegisterAutoFactory<IActionFactory>();
        }
    }
}