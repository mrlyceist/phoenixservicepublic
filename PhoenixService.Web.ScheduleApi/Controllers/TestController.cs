using PhoenixService.ScheduleApp.Specifications.Actions;
using System.Threading.Tasks;
using System.Web.Http;

namespace PhoenixService.Web.ScheduleApi.Controllers
{
    [Authorize]
    public class TestController : ApiController
    {
        private readonly ITestAction testAction;

        public TestController(ITestAction testAction)
        {
            this.testAction = testAction;
        }

        [HttpPost]
        [Route("CreateTask")]
        public async Task CreateTask(string phoneNumber)
        {
            await testAction.ScheduleContact(phoneNumber);
        }
    }
}