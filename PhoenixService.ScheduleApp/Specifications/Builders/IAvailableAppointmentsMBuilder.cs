using PhoenixService.Domain;
using PhoenixService.ScheduleApp.Dto;
using System.Collections.Generic;

namespace PhoenixService.ScheduleApp.Specifications.Builders
{
    public interface IAvailableAppointmentsMBuilder
    {
        AvailableAppointmentsM Build(string requestId, IList<Appointment> appointments);
    }
}