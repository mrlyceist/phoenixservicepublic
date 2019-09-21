using PhoenixService.Domain;

namespace PhoenixService.Data.Interfaces.Factories
{
    public interface IPatientFactory
    {
        Patient Create(string phoenixId, string firstName, string patronymic, string surname);
    }
}