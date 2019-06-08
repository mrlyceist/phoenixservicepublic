using PhoenixService.Domain;
using PhoenixService.ScheduleApp.Dto;
using PhoenixService.ScheduleApp.Specifications.Builders;

namespace PhoenixService.ScheduleApp.Builders
{
    public class SpecialistWithScheduleMBuilder : ISpecialistWithScheduleMBuilder
    {
        public SpecialistWithScheduleM Build(Appointment appointment)
        {
            return new SpecialistWithScheduleM
            {
                Name = appointment.Specialist.Sfp,
                Speciality = appointment.Specialist.Speciality,
                NearestFreeAppointmentDate = appointment.DateTimeStart.Value.Date
            };
        }
    }
}