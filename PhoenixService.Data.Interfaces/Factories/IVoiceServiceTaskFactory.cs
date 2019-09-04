using PhoenixService.Domain;
using System;

namespace PhoenixService.Data.Interfaces.Factories
{
    public interface IVoiceServiceTaskFactory
    {
        VoiceServiceTask Create(string phone,
            string clientName,
            string phoenixTaskId,
            int phoenixType,
            string requestText,
            Guid scenarioId,
            VoiceServiceServer serverType,
            string smsText,
            string spList,
            VoiceServiceTaskStage stage,
            VoiceServiceTaskState state);
    }
}