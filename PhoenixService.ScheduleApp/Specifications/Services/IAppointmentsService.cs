using PhoenixService.Domain;
using PhoenixService.ScheduleApp.Dto;
using System.Threading.Tasks;

namespace PhoenixService.ScheduleApp.Specifications.Services
{
    public interface IAppointmentsService
    {
        Task<Appointment> GetNearestByRequestIdAsync(string requestId);
        Task<bool> TryTakeAppointment(TakeAppointmentM takeAppointmentM);
        Task<Appointment[]> GetAvailableByDate(GetAppointmentsM getAppointmentsM);
    }
}