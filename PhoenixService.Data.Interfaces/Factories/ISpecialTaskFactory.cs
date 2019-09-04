using System;
using PhoenixService.Domain;

namespace PhoenixService.Data.Interfaces.Factories
{
    public interface ISpecialTaskFactory
    {
        SpecialTask Create(string patientName,
            DateTime dateIn,
            string departmentPhoenixId,
            string specialistPhoenixId,
            string especialListPhoenixId,
            int initializeType,
            string operatorPhoenixId,
            DateTime? startTime = null,
            string phoenixId = null);
    }
}