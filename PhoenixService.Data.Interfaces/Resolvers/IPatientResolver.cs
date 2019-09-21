using System.Threading.Tasks;
using PhoenixService.Domain;

namespace PhoenixService.Data.Interfaces.Resolvers
{
    public interface IPatientResolver
    {
        Task<Patient> GetByRequestId(string requestId);
    }
}