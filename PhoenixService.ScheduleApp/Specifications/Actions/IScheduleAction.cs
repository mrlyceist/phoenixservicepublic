using System.Threading.Tasks;
using PhoenixService.ScheduleApp.Dto;

namespace PhoenixService.ScheduleApp.Specifications.Actions
{
    public interface IScheduleAction
    {
        Task<SpecialistWithScheduleM> GetNearestAppointments(string requestId);
        Task<AvailableAppointmentsM> GetAvailableAppointments(GetSpecialistScheduleM getSpecialistScheduleM);
    }
}