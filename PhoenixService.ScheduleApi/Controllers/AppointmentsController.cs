using Microsoft.AspNetCore.Mvc;
using PhoenixService.ScheduleApp.Dto;
using PhoenixService.ScheduleApp.Specifications.Actions;
using System.Threading.Tasks;

namespace PhoenixService.ScheduleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentsAction appointmentsAction;

        public AppointmentsController(IAppointmentsAction appointmentsAction)
        {
            this.appointmentsAction = appointmentsAction;
        }

        /// <summary>
        /// Делает попытку занять прием у специалиста на выбранную дату и время
        /// </summary>
        /// <param name="takeAppointmentM"></param>
        /// <returns>true, в случае успешной записи, иначе - false</returns>
        [HttpPost]
        [Route("TakeAppointment")]
        public async Task<bool> TakeAppointment(TakeAppointmentM takeAppointmentM)
        {
            return await appointmentsAction.TakeAppointment(takeAppointmentM);
        }
    }
}