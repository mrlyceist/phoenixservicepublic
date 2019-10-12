using PhoenixService.Domain;
using System.Linq;

namespace PhoenixService.Data.Interfaces.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> Query();
    }
}