using PhoenixService.Data.Interfaces;
using PhoenixService.Data.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace PhoenixService.Data
{
    public class Store : IStore
    {
        private readonly StoreContext storeContext;

        public Store()
        {
            storeContext = new StoreContext();
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