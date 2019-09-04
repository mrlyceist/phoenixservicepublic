using PhoenixService.Data.Interfaces.Repositories;
using PhoenixService.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace PhoenixService.Data.Repositories
{
    // TODO: Implement (#5, #6)
    public class AppointmentRepository : IAppointmentRepository
    {
        public IQueryable<Appointment> Query()
        {
            throw new System.NotImplementedException();
        }

        public Task Save(Appointment appointment)
        {
            throw new System.NotImplementedException();
        }
    }
}