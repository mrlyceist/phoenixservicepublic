using PhoenixService.Data.Interfaces.Factories;
using PhoenixService.Domain;
using System;

namespace PhoenixService.Data.Factories
{
    public class SpecialTaskFactory : ISpecialTaskFactory
    {
        public SpecialTask Create(string patientName,
            DateTime dateIn,
            string departmentPhoenixId,
            string specialistPhoenixId,
            string especialListPhoenixId,
            int initializeType,
            string operatorPhoenixId,
            DateTime? startTime = null,
            string phoenixId = null)
        {
            return new SpecialTask
            {
                DateIn = dateIn,
                DepartmentPhoenixId = departmentPhoenixId,
                DoctorPhoenixId = specialistPhoenixId,
                EspecialListPhoenixId = especialListPhoenixId,
                InitializeType = initializeType,
                OperatorPhoenixId = operatorPhoenixId,
                PatientName = patientName,
                PhoenixId = phoenixId ?? NCore.Common.Sys2015(),
                StartTime = startTime ?? DateTime.Now
            };
        }
    }
}