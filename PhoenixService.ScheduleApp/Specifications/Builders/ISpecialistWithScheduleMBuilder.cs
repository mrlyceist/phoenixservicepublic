using PhoenixService.Domain;
using PhoenixService.ScheduleApp.Dto;

namespace PhoenixService.ScheduleApp.Specifications.Builders
{
    public interface ISpecialistWithScheduleMBuilder
    {
        SpecialistWithScheduleM Build(Appointment appointment);
    }
}