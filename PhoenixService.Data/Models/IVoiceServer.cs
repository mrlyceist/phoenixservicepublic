using System;
using System.Collections.Generic;

namespace PhoenixService.Data.Models
{
    public partial class IVoiceServer
    {
        public int Server { get; set; }
        public string GetTaskUrl { get; set; }
        public string GetStateUrl { get; set; }
        public string GetResultUrl { get; set; }
        public string GetRecordUrl { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
