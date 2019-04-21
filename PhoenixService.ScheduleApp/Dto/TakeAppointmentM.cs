using System;

namespace PhoenixService.ScheduleApp.Dto
{
    public class TakeAppointmentM
    {
        /// <summary>
        /// ID запроса, сформировавшего дозвон
        /// </summary>
        public string RequestId { get; set; }
        /// <summary>
        /// ID Специалиста
        /// </summary>
        public string SpecialistId { get; set; }
        /// <summary>
        /// Желаемое время начала приема (с датой)
        /// </summary>
        public DateTime Appointment { get; set; }
    }
}