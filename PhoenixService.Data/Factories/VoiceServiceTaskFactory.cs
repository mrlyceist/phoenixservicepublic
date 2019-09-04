using PhoenixService.Data.Interfaces.Factories;
using PhoenixService.Domain;
using System;

namespace PhoenixService.Data.Factories
{
    public class VoiceServiceTaskFactory : IVoiceServiceTaskFactory
    {
        public VoiceServiceTask Create(string phone,
            string clientName,
            string phoenixTaskId,
            int phoenixType,
            string requestText,
            Guid scenarioId,
            VoiceServiceServer serverType,
            string smsText,
            string spList,
            VoiceServiceTaskStage stage,
            VoiceServiceTaskState state)
        {
            return new VoiceServiceTask
            {
                Phone = phone,
                ClientName = clientName,
                PhoenixTaskId = phoenixTaskId,
                PhoenixType = phoenixType,
                RequestText = requestText,
                ScenarioId = scenarioId,
                ServerType = serverType,
                SmsText = smsText,
                SpList = spList,
                Stage = stage,
                State = state
            };
        }
    }
}