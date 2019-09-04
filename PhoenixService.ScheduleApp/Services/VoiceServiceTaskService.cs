using PhoenixService.Data.Interfaces;
using PhoenixService.Data.Interfaces.Factories;
using PhoenixService.Domain;
using PhoenixService.ScheduleApp.Specifications.Services;
using System;
using System.Threading.Tasks;

namespace PhoenixService.ScheduleApp.Services
{
    public class VoiceServiceTaskService : IVoiceServiceTaskService
    {
        private readonly ISpecialTaskFactory specialTaskFactory;
        private readonly IVoiceServiceTaskFactory voiceServiceTaskFactory;
        private readonly IAppConfig config;
        private readonly IStore store;

        public VoiceServiceTaskService(ISpecialTaskFactory specialTaskFactory,
            IVoiceServiceTaskFactory voiceServiceTaskFactory,
            IAppConfig config,
            IStore store)
        {
            this.specialTaskFactory = specialTaskFactory;
            this.voiceServiceTaskFactory = voiceServiceTaskFactory;
            this.config = config;
            this.store = store;
        }

        public async Task SaveTestTask(string phoneNumber)
        {
            const VoiceServiceServer serverType = VoiceServiceServer.OldServer;
            const VoiceServiceTaskStage stage = VoiceServiceTaskStage.NewTask;
            const VoiceServiceTaskState state = VoiceServiceTaskState.Unknown;

            var patientName = config.PatientName;
            var dateIn = DateTime.Now;
            var departmentPhoenixId = config.DepartmentIndex;
            var specialistPhoenixId = config.DoctorIndex;
            var especialListPhoenixId = config.EspecialListIndex;
            var initializeType = config.TaskInitializeType;
            var operatorPhoenixId = config.OperatorIndex;

            var specialTask = specialTaskFactory.Create(patientName,
                dateIn,
                departmentPhoenixId,
                specialistPhoenixId,
                especialListPhoenixId,
                initializeType,
                operatorPhoenixId);

            var phone = phoneNumber.NumberDelPlus();

            var scenarioId = config.ScenarioId;
            var campaignId = config.CompaignId;
            var patientFullName = config.PatientFullName;
            var tag = config.Tag;

            var requestText = $"{{ \"campaign\":\"{campaignId}\"," +
                              $"\"parameters\":" +
                              $"{{ \"FULL_NAME\":\"{patientFullName}\"}}," +
                              $"\"phone\":\"{phone}\",\"tag\":\"{tag}\"}}\"";

            var voiceServiceTask = voiceServiceTaskFactory.Create(phone,
                patientName,
                specialTask.PhoenixId,
                initializeType,
                requestText,
                scenarioId,
                serverType,
                string.Empty,
                especialListPhoenixId,
                stage,
                state);

            await store.IvoiceTaskRepository.SaveAsync(voiceServiceTask);
            await store.SpecialTaskRepository.Save(specialTask);

            await store.SubmitChangesAsync();
        }
    }
}