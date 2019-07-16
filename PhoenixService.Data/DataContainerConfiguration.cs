using System.Data.OleDb;
using LightInject;
using NCore;
using NCore.Factories;
using NCore.Models;
using NCore.Services;
using NCore.Specifications;
using NCore.Specifications.Factories;
using NCore.Specifications.Services;
using PhoenixService.Data.Factories;
using PhoenixService.Data.Interfaces.Factories;
using PhoenixService.Data.Interfaces.Resolvers;
using PhoenixService.Data.Resolvers;

namespace PhoenixService.Data
{
    public static class DataContainerConfiguration
    {
        public static void RegisterDataDependencies(this ServiceContainer container)
        {
            var oledb = new OleDbConnection();
            oledb.Dispose();

            container.Register<IAppointmentFactory, AppointmentFactory>();
            container.Register<ISpecialistFactory, SpecialistFactory>();
            container.Register<IAppointmentsResolver, AppointmentsResolver>();
            container.Register<ISpecialistResolver, SpecialistResolver>();
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
        }
    }
}