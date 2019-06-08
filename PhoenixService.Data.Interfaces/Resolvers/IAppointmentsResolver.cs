using PhoenixService.Domain;
using System.Threading.Tasks;

namespace PhoenixService.Data.Interfaces.Resolvers
{
    public interface IAppointmentsResolver
    {
        Task<Appointment[]> GetNearestByRequestId(string requestId);
    }
}