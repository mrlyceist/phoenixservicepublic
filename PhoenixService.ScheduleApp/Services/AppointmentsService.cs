using PhoenixService.Data.Interfaces.Repositories;
using PhoenixService.Data.Interfaces.Resolvers;
using PhoenixService.Domain;
using PhoenixService.ScheduleApp.Dto;
using PhoenixService.ScheduleApp.Specifications.Services;
using System.Linq;
using System.Threading.Tasks;

namespace PhoenixService.ScheduleApp.Services
{
    public class AppointmentsService : IAppointmentsService
    {
        private readonly IAppointmentsResolver appointmentsResolver;
        private readonly IAppointmentRepository appointmentRepository;

        public AppointmentsService(IAppointmentsResolver appointmentsResolver,
            IAppointmentRepository appointmentRepository)
        {
            this.appointmentsResolver = appointmentsResolver;
            this.appointmentRepository = appointmentRepository;
        }

        public async Task<Appointment> GetNearestByRequestIdAsync(string requestId)
        {
            var appointments = await appointmentsResolver.GetNearestByRequestId(requestId);

            var nearest = appointments.First();

            return nearest;
        }

        public async Task<Appointment[]> GetAvailableByDate(GetAppointmentsM getAppointmentsM)
        {
            var appointments = await appointmentsResolver.GetNearestByRequestId(getAppointmentsM.RequestId);

            // TODO: Validation
            return appointments
                .Where(a => a.DateTimeStart.Value.Date == getAppointmentsM.DateWanted)
                .ToArray();
        }

        public async Task<bool> TryTakeAppointment(TakeAppointmentM takeAppointmentM)
        {
            var appointments = await appointmentsResolver.GetNearestByRequestId(takeAppointmentM.RequestId);
            var appointment = appointments.FirstOrDefault(a => a.PhoenixId == takeAppointmentM.AppointmentId);

            if (appointment == null)
                return false;

            await appointmentRepository.Save(appointment);

            return true;
        }
    }
}