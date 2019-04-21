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
        private readonly IAppointmentsAction appointmentsAction;

        public ScheduleController(IActionFactory actionFactory, IAppointmentsAction appointmentsAction)
        {
            this.actionFactory = actionFactory;
            this.appointmentsAction = appointmentsAction;
        }

        /// <summary>
        /// Возвращает специалиста, у которого был последний прием пациента и дату ближайшего возможного приема
        /// </summary>
        /// <param name="requestId">ID запроса, сформировавшего дозвон</param>
        /// <returns>Специалист и дата его ближайшего доступного приема</returns>
        [HttpGet]
        public Task<SpecialistWithScheduleM> GetNearestAvailableAppointment(string requestId)
        {
            //return actionFactory.GetAction<IAppointmentsAction>().GetNearestAppointments(requestId);
            return appointmentsAction.GetNearestAppointments(requestId);
        }

        //// GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
