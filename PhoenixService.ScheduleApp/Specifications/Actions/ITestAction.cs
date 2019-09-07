using System.Threading.Tasks;

namespace PhoenixService.ScheduleApp.Specifications.Actions
{
    public interface ITestAction
    {
        Task ScheduleContact(string phoneNumber);
    }
}