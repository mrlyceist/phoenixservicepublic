using PhoenixService.ScheduleApp.Dto;
using PhoenixService.ScheduleApp.Specifications.Actions;
using System;
using System.Threading.Tasks;

namespace PhoenixService.ScheduleApp.Actions
{
    public class AppointmentsAction : IAppointmentsAction
    {
        public Task<bool> TakeAppointment(TakeAppointmentM takeAppointmentM)
        {
            throw new NotImplementedException();
        }
    }
}