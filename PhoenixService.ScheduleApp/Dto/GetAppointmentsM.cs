using System;

namespace PhoenixService.ScheduleApp.Dto
{
    public class GetAppointmentsM
    {
        /// <summary>
        /// ID запроса, сформировавшего дозвон
        /// </summary>
        public string RequestId { get; set; }
        /// <summary>
        /// Желаемая дата записи
        /// </summary>
        public DateTime DateWanted { get; set; }
    }
}