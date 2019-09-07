using PhoenixService.ScheduleApp.Specifications.Services;
using System.Threading.Tasks;

namespace PhoenixService.ScheduleApp.Actions
{
    public class TestAction : ITestAction
    {
        private readonly IVoiceServiceTaskService voiceServiceTaskService;

        public TestAction(IVoiceServiceTaskService voiceServiceTaskService)
        {
            this.voiceServiceTaskService = voiceServiceTaskService;
        }

        public async Task ScheduleContact(string phoneNumber)
        {
            await voiceServiceTaskService.SaveTestTask(phoneNumber);
        }
    }
}