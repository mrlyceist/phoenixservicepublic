using PhoenixService.Domain.Exceptions;
using PhoenixService.ScheduleApp.Specifications.Actions;
using PhoenixService.ScheduleApp.Specifications.Services;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhoenixService.ScheduleApp.Actions
{
    public class TestAction : ITestAction
    {
        private readonly IVoiceServiceTaskService voiceServiceTaskService;
        private readonly Regex phoneRegex = new Regex(@"((\+7)|8)(\d{10})", RegexOptions.Compiled);

        public TestAction(IVoiceServiceTaskService voiceServiceTaskService)
        {
            this.voiceServiceTaskService = voiceServiceTaskService;
        }

        public async Task ScheduleContact(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new BadRequestException("Phone number is required");
            if (!phoneRegex.IsMatch(phoneNumber))
                throw new BadRequestException("Invalid phone number");

            await voiceServiceTaskService.SaveTestTask(phoneNumber);
        }
    }
}