using PhoenixService.Domain;
using System.Threading.Tasks;

namespace PhoenixService.Data.Interfaces.Resolvers
{
    public interface IUserResolver
    {
        Task<User> GetByLogin(string login);
    }
}