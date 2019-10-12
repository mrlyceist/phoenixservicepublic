using PhoenixService.Domain;
using System.Threading.Tasks;

namespace PhoenixService.Data.Interfaces.Resolvers
{
    public interface IClientReslover
    {
        Task<Client> GetByClientId(string id);
    }
}