using NCore.Models;
using NCore.Specifications.Factories;
using PhoenixService.Data.Interfaces;
using PhoenixService.Data.Interfaces.Repositories;
using PhoenixService.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace PhoenixService.Data
{
    public class Store : IStore
    {
        private readonly StoreContext storeContext;
        private readonly IEntityFactory<Duty> dutyFactory;
        private readonly IEntityFactory<EspecialTask> especialTaskFactory;
        private readonly IDataConfig config;

        public Store(IEntityFactory<Duty> dutyFactory,
            IEntityFactory<EspecialTask> especialTaskFactory,
            IDataConfig config)
        {
            this.dutyFactory = dutyFactory;
            this.especialTaskFactory = especialTaskFactory;
            this.config = config;
            storeContext = new StoreContext();

            AppointmentRepository = new AppointmentRepository(dutyFactory, config);
            SpecialTaskRepository = new SpecialTaskRepository(especialTaskFactory);
            IvoiceTaskRepository = new IVoiceTaskRepository(storeContext);
        }

        public IAppointmentRepository AppointmentRepository { get; }
        public IIvoiceTaskRepository IvoiceTaskRepository { get; }
        public ISpecialTaskRepository SpecialTaskRepository { get; }

        public Task SubmitChangesAsync()
        {
            return storeContext.SubmitChangesAsync();
        }

        public void AfterSubmitChanges(Action action)
        {
            storeContext.AfterSubmitChanges(action);
        }
    }
}