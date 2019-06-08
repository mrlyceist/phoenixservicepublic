using PhoenixService.Domain;

namespace PhoenixService.Data.Interfaces.Factories
{
    public interface ISpecialistFactory
    {
        Specialist Create(string phoenixId, string sfp, string speciality);
    }
}