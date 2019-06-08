using PhoenixService.Domain;
using PhoenixService.ScheduleApp.Dto;
using PhoenixService.ScheduleApp.Specifications.Builders;
using System.Collections.Generic;
using System.Linq;

namespace PhoenixService.ScheduleApp.Builders
{
    public class AvailableAppointmentsMBuilder : IAvailableAppointmentsMBuilder
    {
        public AvailableAppointmentsM Build(string requestId, IList<Appointment> appointments)
        {
            return new AvailableAppointmentsM
            {
                RequestId = requestId,
                AvailableAppointments = appointments.Select(BuildAppointmentM).ToArray()
            };
        }

        private AppointmentM BuildAppointmentM(Appointment appointment)
        {
            return new AppointmentM
            {
                AppointmentId = appointment.PhoenixId,
                StartDateTime = appointment.DateTimeStart.Value
            };
        }
    }
}