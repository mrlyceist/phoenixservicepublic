using PhoenixService.Domain;
using System.Linq;

namespace PhoenixService.Data.Interfaces.Repositories
{
    public interface IClientRepository
    {
        IQueryable<Client> Query();
    }
}