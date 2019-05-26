using PhoenixService.ScheduleApp.Dto;
using System.Threading.Tasks;
using PhoenixService.ScheduleApp.Specifications.Actions;

namespace PhoenixService.ScheduleApp.Actions
{
    public class AppointmentsAction : IAppointmentsAction
    {
        public Task<bool> TakeAppointment(TakeAppointmentM takeAppointmentM)
        {
            
        }
    }
}