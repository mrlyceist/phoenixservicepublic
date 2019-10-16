using NCore.Models;
using NCore.Specifications.Factories;
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
            IEntityFactory<Specialty> specialtyFactory)
        {
            this.employeeFactory = employeeFactory;
            this.specialistFactory = specialistFactory;
            this.specialtyFactory = specialtyFactory;
        }

        public Specialist GetByPhoenixId(string phoenixId)
        {
            var employee = employeeFactory.GetFromDb(phoenixId);
            if (employee == null)
                throw new Exception($"Specialist {phoenixId} not found");

            var speciality = specialtyFactory.GetFromDb(employee.SpecialtyId);
            if (speciality == null)
                throw new Exception($"Speciality {employee.SpecialtyId} not found for specialist {phoenixId}");

            var specialist = specialistFactory.Create(employee.IndCode, employee.FirstLastName, speciality.Name);

            return specialist;
        }
    }
}