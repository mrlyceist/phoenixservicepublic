using System;

namespace PhoenixService.ScheduleApp.Dto
{
    public class AppointmentM
    {
        /// <summary>
        /// ID приема
        /// </summary>
        public string AppointmentId { get; set; }
        /// <summary>
        /// Дата и время начала приема
        /// </summary>
        public DateTime StartDateTime { get; set; }
    }
}