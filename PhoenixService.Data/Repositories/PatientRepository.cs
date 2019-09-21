using NCore.Specifications;
using PhoenixService.Data.Interfaces.Factories;
using System.Threading.Tasks;
using PhoenixService.Data.Interfaces.Repositories;
using DomainPatient = PhoenixService.Domain.Patient;

namespace PhoenixService.Data.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IIVoiceDuty iVoiceDuty;
        private readonly IPatientFactory patientFactory;

        public PatientRepository(IIVoiceDuty iVoiceDuty, IPatientFactory patientFactory)
        {
            this.iVoiceDuty = iVoiceDuty;
            this.patientFactory = patientFactory;
        }

        public Task<DomainPatient> GetByRequestId(string requestId)
        {
            var clientCallReason = iVoiceDuty.GetClientCallReason(requestId);

            var patient = patientFactory.Create(clientCallReason.ClientCode, string.Empty, string.Empty, string.Empty);

            return Task.FromResult(patient);
        }
    }
}