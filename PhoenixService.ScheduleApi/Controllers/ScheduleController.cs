using Microsoft.AspNetCore.Mvc;
using PhoenixService.ApiInfrastructure;
using PhoenixService.ScheduleApp.Dto;
using PhoenixService.ScheduleApp.Specifications.Actions;
using System.Threading.Tasks;

namespace PhoenixService.ScheduleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IActionFactory actionFactory;
        private readonly IScheduleAction scheduleAction;

        public ScheduleController(IActionFactory actionFactory,
            IScheduleAction scheduleAction)
        {
            this.actionFactory = actionFactory;
            this.scheduleAction = scheduleAction;
        }

        /// <summary>
        /// Возвращает специалиста, у которого был последний прием пациента и дату ближайшего возможного приема
        /// </summary>
        /// <param name="requestId">ID запроса, сформировавшего дозвон</param>
        /// <returns>Специалист и дата его ближайшего доступного приема</returns>
        [HttpGet]
        [Route("GetNearestAppointment")]
        public async Task<SpecialistWithScheduleM> GetNearestAppointment(string requestId)
        {
            return await scheduleAction.GetNearestAppointments(requestId);
        }

        /// <summary>
        /// Возвращает доступные приемы для заданного RequestId на желаемую дату
        /// </summary>
        /// <param name="getAppointmentsM"></param>
        /// <returns><see cref="AvailableAppointmentsM"/></returns>
        [HttpPost]
        [Route("GetAvailableAppointments")]
        public async Task<AvailableAppointmentsM> GetAvailableAppointments(GetAppointmentsM getAppointmentsM)
        {
            return await scheduleAction.GetAvailableAppointments(getAppointmentsM);
        }
    }
}
