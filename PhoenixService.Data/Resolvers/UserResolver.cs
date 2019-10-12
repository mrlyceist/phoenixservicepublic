using PhoenixService.Data.Interfaces.Repositories;
using PhoenixService.Data.Interfaces.Resolvers;
using PhoenixService.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PhoenixService.Data.Resolvers
{
    public class UserResolver : IUserResolver
    {
        private readonly IUserRepository userRepository;

        public UserResolver(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Task<User> GetByLogin(string login)
        {
            return Task.FromResult(userRepository.Query()
                .FirstOrDefault(u => string.Equals(u.Login, login, StringComparison.InvariantCultureIgnoreCase)));
        }
    }
}