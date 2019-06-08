using PhoenixService.ScheduleApp.Dto;
using PhoenixService.ScheduleApp.Specifications.Actions;
using PhoenixService.ScheduleApp.Specifications.Builders;
using PhoenixService.ScheduleApp.Specifications.Services;
using System.Threading.Tasks;

namespace PhoenixService.ScheduleApp.Actions
{
    public class ScheduleAction : IScheduleAction
    {
        private readonly IAppointmentsService appointmentsService;
        private readonly IAvailableAppointmentsMBuilder availableAppointmentsMBuilder;
        private readonly ISpecialistWithScheduleMBuilder specialistWithScheduleMBuilder;

        public ScheduleAction(IAvailableAppointmentsMBuilder availableAppointmentsMBuilder,
            IAppointmentsService appointmentsService,
            ISpecialistWithScheduleMBuilder specialistWithScheduleMBuilder)
        {
            this.availableAppointmentsMBuilder = availableAppointmentsMBuilder;
            this.appointmentsService = appointmentsService;
            this.specialistWithScheduleMBuilder = specialistWithScheduleMBuilder;
        }

        public async Task<SpecialistWithScheduleM> GetNearestAppointments(string requestId)
        {
            var nearestAppointment = await appointmentsService.GetNearestByRequestIdAsync(requestId);

            return specialistWithScheduleMBuilder.Build(nearestAppointment);
        }

        public async Task<AvailableAppointmentsM> GetAvailableAppointments(GetAppointmentsM getAppointmentsM)
        {
            var appintments = await appointmentsService.GetAvailableByDate(getAppointmentsM);

            return availableAppointmentsMBuilder.Build(getAppointmentsM.RequestId, appintments);
        }
    }
}