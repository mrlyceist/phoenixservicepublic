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

        public AppointmentsController(IAppointmentsAction appointmentsAction)
        {
            this.appointmentsAction = appointmentsAction;
        }

        [HttpPost]
        [Route("TakeAppointment")]
        public async Task<bool> TakeAppointment(TakeAppointmentM takeAppointmentM)
        {
            return await appointmentsAction.TakeAppointment(takeAppointmentM);
        }
    }
}