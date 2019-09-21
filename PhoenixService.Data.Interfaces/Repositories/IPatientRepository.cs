using PhoenixService.Domain;
using System.Threading.Tasks;

namespace PhoenixService.Data.Interfaces.Repositories
{
    public interface IPatientRepository
    {
        Task<Patient> GetByRequestId(string requestId);
    }
}