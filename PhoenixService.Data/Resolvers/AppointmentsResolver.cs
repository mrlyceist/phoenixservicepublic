using PhoenixService.Data.Interfaces.Resolvers;
using PhoenixService.Domain;
using System;
using NCore;

namespace PhoenixService.Data.Resolvers
{
    public class AppointmentsResolver : IAppointmentsResolver
    {
        private readonly IFoxDbInteractor dbInteractor;

        public AppointmentsResolver(IFoxDbInteractor dbInteractor)
        {
            this.dbInteractor = dbInteractor;
        }

        public Appointment[] GetNearestByRequestId(string requestId)
        {
            dbInteractor.InitializeConnection()
        }
    }
}