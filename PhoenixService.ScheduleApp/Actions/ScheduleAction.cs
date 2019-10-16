using PhoenixService.Domain.Exceptions;
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
            if (string.IsNullOrWhiteSpace(requestId))
                throw new BadRequestException("Request Id is required");

            var nearestAppointment = await appointmentsService.GetNearestByRequestIdAsync(requestId);

            return specialistWithScheduleMBuilder.Build(nearestAppointment);
        }

        public async Task<AvailableAppointmentsM> GetAvailableAppointments(GetAppointmentsM getAppointmentsM)
        {
            if (string.IsNullOrWhiteSpace(getAppointmentsM.RequestId))
                throw new BadRequestException("Request Id is required");

            var appintments = await appointmentsService.GetAvailableByDate(getAppointmentsM);

            return availableAppointmentsMBuilder.Build(getAppointmentsM.RequestId, appintments);
        }
    }
}