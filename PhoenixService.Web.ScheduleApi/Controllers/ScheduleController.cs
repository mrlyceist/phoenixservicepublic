using PhoenixService.ScheduleApp.Dto;
using PhoenixService.ScheduleApp.Specifications.Actions;
using System.Threading.Tasks;
using System.Web.Http;

namespace PhoenixService.Web.ScheduleApi.Controllers
{
    public class ScheduleController : ApiController
    {
        private readonly IScheduleAction scheduleAction;

        public ScheduleController(IScheduleAction scheduleAction)
        {
            this.scheduleAction = scheduleAction;
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
            return await scheduleAction.GetAvailableAppointments(getAppointmentsM);
        }
    }
}