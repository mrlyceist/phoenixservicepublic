using PhoenixService.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PhoenixService.Data.Interfaces.Repositories
{
    public interface IIvoiceTaskRepository
    {
        IQueryable<VoiceServiceTask> Query();
        Task SaveAsync(VoiceServiceTask task);
        Task Delete(Guid taskId);
    }
}