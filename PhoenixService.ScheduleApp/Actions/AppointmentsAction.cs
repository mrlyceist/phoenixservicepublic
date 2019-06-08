using PhoenixService.ScheduleApp.Dto;
using PhoenixService.ScheduleApp.Specifications.Actions;
using PhoenixService.ScheduleApp.Specifications.Services;
using System.Threading.Tasks;

namespace PhoenixService.ScheduleApp.Actions
{
    public class AppointmentsAction : IAppointmentsAction
    {
        private readonly IAppointmentsService appointmentsService;

        public AppointmentsAction(IAppointmentsService appointmentsService)
        {
            this.appointmentsService = appointmentsService;
        }

        public Task<bool> TakeAppointment(TakeAppointmentM takeAppointmentM)
        {
            return appointmentsService.TryTakeAppointment(takeAppointmentM);
        }
    }
}