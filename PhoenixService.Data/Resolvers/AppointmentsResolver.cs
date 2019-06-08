using NCore.Specifications;
using PhoenixService.Data.Interfaces;
using PhoenixService.Data.Interfaces.Factories;
using PhoenixService.Data.Interfaces.Resolvers;
using PhoenixService.Domain;
using System;
using System.Linq;

namespace PhoenixService.Data.Resolvers
{
    public class AppointmentsResolver : IAppointmentsResolver
    {
        private readonly IDataConfiguration configuration;
        private readonly IFoxDbInteractor dbInteractor;
        private readonly IIVoiceDuty iVoiceDuty;
        private readonly IAppointmentFactory appointmentFactory;

        public AppointmentsResolver(IFoxDbInteractor dbInteractor,
            IDataConfiguration configuration,
            IIVoiceDuty iVoiceDuty,
            IAppointmentFactory appointmentFactory)
        {
            this.dbInteractor = dbInteractor;
            this.configuration = configuration;
            this.iVoiceDuty = iVoiceDuty;
            this.appointmentFactory = appointmentFactory;
        }

        public Appointment[] GetNearestByRequestId(string requestId)
        {
            dbInteractor.InitializeConnection(configuration.PhoenixExecutablePath);

            var clientCallReason = iVoiceDuty.GetClientCallReason(requestId);
            var doctorId = iVoiceDuty.GetDoctor(clientCallReason);
            var depth = iVoiceDuty.GetSeekDepth(clientCallReason);
            var length = iVoiceDuty.GetVisitLenght(clientCallReason);

            var duties = iVoiceDuty.OfferTime(clientCallReason.ClientCode, doctorId, length, depth);

            var appointments =
                duties.Select(d => appointmentFactory.Build(d.StartTime, d.EndTime, null, null, d.Index));

            return Array.Empty<Appointment>();
        }
    }
}