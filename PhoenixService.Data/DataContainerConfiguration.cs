using LightInject;
using NCore;
using NCore.Factories;
using NCore.Models;
using NCore.Services;
using NCore.Specifications;
using NCore.Specifications.Factories;
using NCore.Specifications.Services;
using PhoenixService.Data.Factories;
using PhoenixService.Data.Interfaces;
using PhoenixService.Data.Interfaces.Factories;
using PhoenixService.Data.Interfaces.Repositories;
using PhoenixService.Data.Interfaces.Resolvers;
using PhoenixService.Data.Repositories;
using PhoenixService.Data.Resolvers;

namespace PhoenixService.Data
{
    public static class DataContainerConfiguration
    {
        public static void RegisterDataDependencies(this ServiceContainer container)
        {
            // Factories
            container.Register<IAppointmentFactory, AppointmentFactory>();
            container.Register<IPatientFactory, Factories.PatientFactory>();
            container.Register<ISpecialistFactory, SpecialistFactory>();
            container.Register<ISpecialTaskFactory, SpecialTaskFactory>();
            container.Register<IVoiceServiceTaskFactory, VoiceServiceTaskFactory>();
            // Repositories
            container.Register<IAppointmentRepository, AppointmentRepository>();
            container.Register<IPatientRepository, PatientRepository>();
            container.Register<IIvoiceTaskRepository, IVoiceTaskRepository>();
            container.Register<ISpecialTaskRepository, SpecialTaskRepository>();
            container.Register<IUserRepository, UserRepository>();
            container.Register<IClientRepository, ClientRepository>();
            // Resolvers
            container.Register<IAppointmentsResolver, AppointmentsResolver>();
            container.Register<IPatientResolver, PatientResolver>();
            container.Register<ISpecialistResolver, SpecialistResolver>();
            container.Register<IUserResolver, UserResolver>();
            container.Register<IClientReslover, ClientReslover>();
            // Miscellaneous
            container.Register<IStore, Store>();
            // NCore: Miscellaneous
            container.Register<IFoxDbInteractor, FoxDbInteractor>(new PerContainerLifetime());
            container.Register<ICategoryTransform, CategoryTransform>();
            container.Register<IPhoenixSetupService, PhoenixSetupService>();
            container.Register<IIVoiceDuty, IVoiceDuty>();
            container.Register<IScheduleService, ScheduleService>();
            // NCore: EntityFactories
            container.Register<IEntityFactory<Employee>, EmployeeFactory>();
            container.Register<IEntityFactory<Kdg>, KdgFactory>();
            container.Register<IEntityFactory<Duty>, DutyFactory>();
            container.Register<IEntityFactory<Patient>, NCore.Factories.PatientFactory>();
            container.Register<IEntityFactory<Department>, DepartmentFactory>();
            container.Register<IEntityFactory<Specialty>, SpecialtyFactory>();
            container.Register<IEntityFactory<EspecialTask>, EspecialTaskFactory>();

            var dbInteractor = container.GetInstance<IFoxDbInteractor>();
            var config = container.GetInstance<IDataConfiguration>();
            dbInteractor.InitializeConnection(config.PhoenixDbPath);
        }
    }
}