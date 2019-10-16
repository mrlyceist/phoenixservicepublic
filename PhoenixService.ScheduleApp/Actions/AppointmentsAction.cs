using PhoenixService.Domain.Exceptions;
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
            if (string.IsNullOrWhiteSpace(takeAppointmentM.RequestId))
                throw new BadRequestException("Request Id is required");
            if (string.IsNullOrWhiteSpace(takeAppointmentM.AppointmentId))
                throw new BadRequestException("Appointment Id is required");

            return appointmentsService.TryTakeAppointment(takeAppointmentM);
        }
    }
}