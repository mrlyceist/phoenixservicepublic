using PhoenixService.Data.Interfaces.Repositories;
using PhoenixService.Data.Interfaces.Resolvers;
using PhoenixService.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PhoenixService.Data.Resolvers
{
    public class ClientReslover : IClientReslover
    {
        private readonly IClientRepository clientRepository;

        public ClientReslover(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public Task<Client> GetByClientId(string id)
        {
            return Task.FromResult(clientRepository.Query()
                .FirstOrDefault(c => string.Equals(c.Id.ToString(), id, StringComparison.InvariantCultureIgnoreCase)));
        }
    }
}