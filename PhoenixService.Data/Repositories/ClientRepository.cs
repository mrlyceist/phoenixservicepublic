using PhoenixService.Data.Interfaces.Repositories;
using PhoenixService.Domain;
using System;
using System.Linq;

namespace PhoenixService.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        public IQueryable<Client> Query()
        {
            var client = new Client
            {
                Id = new Guid("EA4A6232-2955-4256-A40C-9F13F279309B"),
                Name = "denta-ivoice",
                ApiKey = "eQbEyIsPmK4nBijqosZj4OcwF3JvnWfs",
                Expires = new DateTime(2020, 6, 1)
            };

            var clients = new[] { client }.AsQueryable();

            return clients;
        }
    }
}