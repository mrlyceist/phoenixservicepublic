using PhoenixService.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace PhoenixService.Data.Interfaces.Repositories
{
    public interface IAppointmentRepository
    {
        IQueryable<Appointment> Query();
        Task Save(Appointment appointment);
    }
}