using PhoenixService.Domain;

namespace PhoenixService.Data.Interfaces.Resolvers
{
    public interface IAppointmentsResolver
    {
        Appointment[] GetNearestByRequestId(string requestId);
    }
}