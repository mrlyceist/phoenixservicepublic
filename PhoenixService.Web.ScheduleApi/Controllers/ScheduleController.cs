using Microsoft.Extensions.Logging;
using PhoenixService.ScheduleApp.Dto;
using PhoenixService.ScheduleApp.Specifications.Actions;
using System.Threading.Tasks;
using System.Web.Http;

namespace PhoenixService.Web.ScheduleApi.Controllers
{
    [Authorize]
    public class ScheduleController : ApiController
    {
        private readonly IScheduleAction scheduleAction;
        private readonly ILogger logger;

        public ScheduleController(IScheduleAction scheduleAction, ILogger logger)
        {
            this.scheduleAction = scheduleAction;
            this.logger = logger;
        }

        [HttpGet]
        [Route("GetNearestAppointments")]
        public async Task<SpecialistWithScheduleM> GetNearestAppointments(string requestId)
        {
            return await scheduleAction.GetNearestAppointments(requestId);
        }

        [HttpGet]
        [Route("GetAvailableAppointments")]
        public async Task<AvailableAppointmentsM> GetAvailableAppointments([FromUri]GetAppointmentsM getAppointmentsM)
        {
            logger.LogInformation($"{GetType()}: Identity: {RequestContext.Principal.Identity}, params: {getAppointmentsM}");

            return await scheduleAction.GetAvailableAppointments(getAppointmentsM);
        }
    }
}