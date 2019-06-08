using NCore.Models;
using NCore.Specifications;
using NCore.Specifications.Factories;
using PhoenixService.Data.Interfaces;
using PhoenixService.Data.Interfaces.Factories;
using PhoenixService.Data.Interfaces.Resolvers;
using PhoenixService.Domain;
using System;

namespace PhoenixService.Data.Resolvers
{
    public class SpecialistResolver : ISpecialistResolver
    {
        private readonly IEntityFactory<Employee> employeeFactory;
        private readonly ISpecialistFactory specialistFactory;
        private readonly IEntityFactory<Specialty> specialtyFactory;

        public SpecialistResolver(IEntityFactory<Employee> employeeFactory,
            ISpecialistFactory specialistFactory,
            IDataConfiguration configuration,
            IFoxDbInteractor foxDbInteractor,
            IEntityFactory<Specialty> specialtyFactory)
        {
            this.employeeFactory = employeeFactory;
            this.specialistFactory = specialistFactory;
            this.specialtyFactory = specialtyFactory;
            foxDbInteractor.InitializeConnection(configuration.PhoenixExecutablePath);
        }

        public Specialist GetByPhoenixId(string phoenixId)
        {
            var employee = employeeFactory.GetFromDb(phoenixId);
            if (employee == null)
                throw new Exception("Specialist not found");

            var speciality = specialtyFactory.GetFromDb(employee.SpecialtyId);

            var specialist = specialistFactory.Create(employee.IndCode, employee.FirstLastName, speciality.Name);

            return specialist;
        }
    }
}