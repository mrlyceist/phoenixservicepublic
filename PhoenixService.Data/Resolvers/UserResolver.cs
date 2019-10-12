using Microsoft.EntityFrameworkCore;
using PhoenixService.Data.Interfaces.Repositories;
using PhoenixService.Domain;
using System;
using System.Threading.Tasks;
using PhoenixService.Data.Interfaces.Resolvers;

namespace PhoenixService.Data.Resolvers
{
    public class UserResolver : IUserResolver
    {
        private readonly IUserRepository userRepository;

        public UserResolver(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> GetByLogin(string login)
        {
            return await userRepository.Query()
                .FirstOrDefaultAsync(u => string.Equals(u.Login, login, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}