using PhoenixService.Data.Interfaces.Factories;
using PhoenixService.Domain;

namespace PhoenixService.Data.Factories
{
    public class SpecialistFactory : ISpecialistFactory
    {
        public Specialist Create(string phoenixId, string sfp, string speciality)
        {
            return new Specialist
            {
                PhoenixId = phoenixId,
                Sfp = sfp,
                Speciality = speciality,
            };
        }
    }
}