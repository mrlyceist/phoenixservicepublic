using PhoenixService.Data.Interfaces.Factories;
using PhoenixService.Domain;

namespace PhoenixService.Data.Factories
{
    public class PatientFactory : IPatientFactory
    {
        public Patient Create(string phoenixId, string firstName, string patronymic, string surname)
        {
            return new Patient
            {
                PhoenixId = phoenixId,
                Sfp = GetSfp(surname, firstName, patronymic)
            };
        }

        private string GetSfp(string surname, string firstName, string patronymic)
        {
            return $"{surname} {firstName} {patronymic}";
        }
    }
}