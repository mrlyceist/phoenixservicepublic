using System.Threading.Tasks;
using PhoenixService.ScheduleApp.Dto;

namespace PhoenixService.ScheduleApp.Specifications.Actions
{
    public interface IAppointmentsAction
    {
        Task<SpecialistWithScheduleM> GetNearestAppointments(string requestId);
    }
}