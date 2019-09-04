using System.Threading.Tasks;

namespace PhoenixService.ScheduleApp.Specifications.Services
{
    public interface IVoiceServiceTaskService
    {
        Task SaveTestTask(string phoneNumber);
    }
}