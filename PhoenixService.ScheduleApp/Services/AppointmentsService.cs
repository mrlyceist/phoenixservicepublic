using PhoenixService.Data.Interfaces.Repositories;
using PhoenixService.Data.Interfaces.Resolvers;
using PhoenixService.Domain;
using PhoenixService.Domain.Exceptions;
using PhoenixService.ScheduleApp.Dto;
using PhoenixService.ScheduleApp.Specifications.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PhoenixService.ScheduleApp.Services
{
    public class AppointmentsService : IAppointmentsService
    {
        private readonly IAppointmentsResolver appointmentsResolver;
        private readonly IAppointmentRepository appointmentRepository;
        private readonly IPatientResolver patientResolver;

        public AppointmentsService(IAppointmentsResolver appointmentsResolver,
            IAppointmentRepository appointmentRepository,
            IPatientResolver patientResolver)
        {
            this.appointmentsResolver = appointmentsResolver;
            this.appointmentRepository = appointmentRepository;
            this.patientResolver = patientResolver;
        }

        public async Task<Appointment> GetNearestByRequestIdAsync(string requestId)
        {
            var appointments = await appointmentsResolver.GetNearestByRequestId(requestId);

            if (appointments.Length == 0)
                throw new NotFoundException($"No appointments for requestId {requestId}");

            var nearest = appointments.First();

            return nearest;
        }

        public async Task<Appointment[]> GetAvailableByDate(GetAppointmentsM getAppointmentsM)
        {
            var appointments = await appointmentsResolver.GetNearestByRequestId(getAppointmentsM.RequestId);

            if (!DateTime.TryParse(getAppointmentsM.DateWanted, out var dateWanted))
                throw new BadRequestException("Invalid date format");

            return appointments
                .Where(a => a.DateTimeStart.Value.Date == dateWanted)
                .ToArray();
        }

        public async Task<bool> TryTakeAppointment(TakeAppointmentM takeAppointmentM)
        {
            var appointments = await appointmentsResolver.GetNearestByRequestId(takeAppointmentM.RequestId);
            var appointment = appointments.FirstOrDefault(a => a.PhoenixId == takeAppointmentM.AppointmentId);

            var patient = await patientResolver.GetByRequestId(takeAppointmentM.RequestId);

            if (appointment == null)
                return false;

            appointment.Patient = patient ?? throw new Exception($"Patient for request {takeAppointmentM.RequestId} not found");

            await appointmentRepository.Save(appointment);

            return true;
        }
    }
}