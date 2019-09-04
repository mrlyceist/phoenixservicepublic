using PhoenixService.Data.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace PhoenixService.Data.Interfaces
{
    public interface IStore
    {
        IAppointmentRepository AppointmentRepository { get; }
        IIvoiceTaskRepository IvoiceTaskRepository { get; }
        ISpecialTaskRepository SpecialTaskRepository { get; }

        void AfterSubmitChanges(Action action);
        Task SubmitChangesAsync();
    }
}