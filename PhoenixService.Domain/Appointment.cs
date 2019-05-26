using System;

namespace PhoenixService.Domain
{
    public class Appointment
    {
        public DateTime? DateTimeStart { get; set; }
        public DateTime? DateTimeEnd { get; set; }
        public string PhoenixId { get; set; }
        public Patient Patient { get; set; }
        public Specialist Specialist { get; set; }

        public TimeSpan? Duration =>
            (DateTimeStart.HasValue && DateTimeEnd.HasValue)
                ? (TimeSpan?)(DateTimeStart.Value - DateTimeEnd.Value)
                : null;
    }
}