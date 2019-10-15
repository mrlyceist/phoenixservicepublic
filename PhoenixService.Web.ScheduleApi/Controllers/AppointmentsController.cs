using Microsoft.Extensions.Logging;
using PhoenixService.ScheduleApp.Dto;
using PhoenixService.ScheduleApp.Specifications.Actions;
using System.Threading.Tasks;
using System.Web.Http;

namespace PhoenixService.Web.ScheduleApi.Controllers
{
    [Authorize]
    public class AppointmentsController : ApiController
    {
        private readonly IAppointmentsAction appointmentsAction;
        private readonly ILogger logger;

        public AppointmentsController(IAppointmentsAction appointmentsAction, ILogger logger)
        {
            this.appointmentsAction = appointmentsAction;
            this.logger = logger;
        }

        [HttpPost]
        [Route("TakeAppointment")]
        public async Task<bool> TakeAppointment(TakeAppointmentM takeAppointmentM)
        {
            logger.LogInformation(
                $"{GetType()}: Identity: {RequestContext.Principal.Identity}, params: {takeAppointmentM}");

            return await appointmentsAction.TakeAppointment(takeAppointmentM);
        }
    }
}