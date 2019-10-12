using PhoenixService.Data.Interfaces.Repositories;
using PhoenixService.Domain;
using System.Linq;

namespace PhoenixService.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public IQueryable<User> Query()
        {
            var user = new User
            {
                Id = 1,
                Login = "denta-ivoice",
                Password = "kL3T6Hp5O3"
            };

            var users = new[] { user }.AsQueryable();

            return users;
        }
    }
}