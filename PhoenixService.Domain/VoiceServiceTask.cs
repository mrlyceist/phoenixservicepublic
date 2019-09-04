using System;

namespace PhoenixService.Domain
{
    public class VoiceServiceTask
    {
        public string Phone { get; set; }
        public string ClientName { get; set; }
        public VoiceServiceTaskState State { get; set; }
        public VoiceServiceServer ServerType { get; set; }
        public string PhoenixTaskId { get; set; }
        public Guid ScenarioId { get; set; }
        public string RequestText { get; set; }
        public string SpList { get; set; }
        public int PhoenixType { get; set; }
        public VoiceServiceTaskStage Stage { get; set; }
        public string SmsText { get; set; }
        public Guid? Id { get; set; }
    }
}