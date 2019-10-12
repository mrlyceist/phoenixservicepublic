using PhoenixService.Data.Interfaces.Resolvers;
using PhoenixService.Domain;
using PhoenixService.ScheduleApp.Specifications.Services;
using System;
using System.Threading.Tasks;

namespace PhoenixService.ScheduleApp.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserResolver userResolver;
        private readonly IClientReslover clientReslover;

        public AuthenticationService(IUserResolver userResolver, IClientReslover clientReslover)
        {
            this.userResolver = userResolver;
            this.clientReslover = clientReslover;
        }

        public async Task<User> ValidateUser(string login, string password)
        {
            var user = await userResolver.GetByLogin(login);
            if (user == null)
                return null;

            // TODO: implement actual password logic (#7)
            if (user.Password != password)
                return null;

            return user;
        }

        public async Task<Client> ValidateClient(string clientId, string apiKey)
        {
            var client = await clientReslover.GetByClientId(clientId);
            if (client == null)
                return null;

            if (client.ApiKey != apiKey)
                return null;
            if (client.Expires < DateTime.Today)
                return null;

            return client;
        }
    }
}