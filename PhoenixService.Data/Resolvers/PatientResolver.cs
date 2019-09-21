using PhoenixService.Data.Interfaces.Repositories;
using PhoenixService.Data.Interfaces.Resolvers;
using PhoenixService.Domain;
using System.Threading.Tasks;

namespace PhoenixService.Data.Resolvers
{
    public class PatientResolver : IPatientResolver
    {
        private readonly IPatientRepository patientRepository;

        public PatientResolver(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        public Task<Patient> GetByRequestId(string requestId)
        {
            return patientRepository.GetByRequestId(requestId);
        }
    }
}