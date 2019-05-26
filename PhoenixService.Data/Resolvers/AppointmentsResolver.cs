using PhoenixService.Data.Interfaces.Resolvers;
using PhoenixService.Domain;
using System;

namespace PhoenixService.Data.Resolvers
{
    public class AppointmentsResolver : IAppointmentsResolver
    {
        public Appointment[] GetNearestByRequestId(string requestId)
        {
            return Array.Empty<Appointment>();
        }
    }
}