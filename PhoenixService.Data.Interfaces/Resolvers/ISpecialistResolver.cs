using PhoenixService.Domain;

namespace PhoenixService.Data.Interfaces.Resolvers
{
    public interface ISpecialistResolver
    {
        Specialist GetByPhoenixId(string phoenixId);
    }
}