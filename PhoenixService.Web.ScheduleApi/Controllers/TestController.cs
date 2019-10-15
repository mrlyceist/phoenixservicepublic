using Microsoft.Extensions.Logging;
using PhoenixService.ScheduleApp.Specifications.Actions;
using System.Threading.Tasks;
using System.Web.Http;

namespace PhoenixService.Web.ScheduleApi.Controllers
{
    [Authorize]
    public class TestController : ApiController
    {
        private readonly ITestAction testAction;
        private readonly ILogger logger;

        public TestController(ITestAction testAction, ILogger logger)
        {
            this.testAction = testAction;
            this.logger = logger;
        }

        [HttpPost]
        [Route("CreateTask")]
        public async Task CreateTask(string phoneNumber)
        {
            logger.LogInformation($"{GetType()}: Identity: {RequestContext.Principal.Identity}, params: {phoneNumber}");

            await testAction.ScheduleContact(phoneNumber);
        }
    }
}