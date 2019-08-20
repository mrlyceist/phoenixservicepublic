using System;
using System.Collections.Generic;

namespace PhoenixService.Data.Models
{
    public partial class IvoiceTask
    {
        public Guid Id { get; set; }
        public DateTime? Moment { get; set; }
        public string Phone { get; set; }
        public string Client { get; set; }
        public string IvoiceRequestId { get; set; }
        public int? IvoiceState { get; set; }
        public int? ServerType { get; set; }
        public string PhoenixTask { get; set; }
        public Guid? Scenario { get; set; }
        public string Anket { get; set; }
        public string RequestText { get; set; }
        public string CallRecord { get; set; }
        public string SmsText { get; set; }
        public int? PhoenixiType { get; set; }
        public string SpList { get; set; }
        public int? Stage { get; set; }
    }
}
