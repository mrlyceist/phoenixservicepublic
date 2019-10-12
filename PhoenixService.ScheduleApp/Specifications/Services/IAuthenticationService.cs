using PhoenixService.Domain;
using System.Threading.Tasks;

namespace PhoenixService.ScheduleApp.Specifications.Services
{
    public interface IAuthenticationService
    {
        Task<Client> ValidateClient(string clientId, string apiKey);
        Task<User> ValidateUser(string login, string password);
    }
}