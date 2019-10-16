using Microsoft.EntityFrameworkCore;
using PhoenixService.Data.Interfaces.Repositories;
using PhoenixService.Data.Models;
using PhoenixService.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PhoenixService.Data.Repositories
{
    // ReSharper disable once InconsistentNaming
    internal class IVoiceTaskRepository : IIvoiceTaskRepository
    {
        private readonly StoreContext context;

        public IVoiceTaskRepository(StoreContext context)
        {
            this.context = context;
        }

        public IQueryable<VoiceServiceTask> Query()
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync(VoiceServiceTask task)
        {
            var dbTask = await context.Db.IvoiceTask
                .SingleOrDefaultAsync(x => x.Id == task.Id);

            if (dbTask == null)
            {
                dbTask = new IvoiceTask();
                context.Db.IvoiceTask.Add(dbTask);
                context.AfterSubmitChanges(() => task.Id = dbTask.Id);
            }

            dbTask.Phone = task.Phone;
            dbTask.Client = task.ClientName;
            dbTask.ServerType = (int)task.ServerType;
            dbTask.PhoenixTask = task.PhoenixTaskId;
            dbTask.Scenario = task.ScenarioId;
            dbTask.RequestText = task.RequestText;
            dbTask.PhoenixiType = task.PhoenixType;
            dbTask.SpList = task.SpList;
            dbTask.Stage = (int)task.Stage;
            dbTask.IvoiceState = (int)task.State;
            dbTask.SmsText = task.SmsText;
        }

        public Task Delete(Guid taskId)
        {
            throw new NotImplementedException();
        }
    }
}