using System;
using System.Collections.Generic;

namespace PhoenixService.Data.Models
{
    public partial class Scenarios
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Dbquery { get; set; }
        public string Smstemplate { get; set; }
        public string RingProcessResult { get; set; }
        public string RingSuccessResult { get; set; }
        public string RingFailureResult { get; set; }
        public string SmssendResult { get; set; }
        public int? ServerType { get; set; }
        public string IVoiceScenarioId { get; set; }
        public string IVoiceQuery { get; set; }
        public string Splist { get; set; }
        public int? Itype { get; set; }
    }
}
