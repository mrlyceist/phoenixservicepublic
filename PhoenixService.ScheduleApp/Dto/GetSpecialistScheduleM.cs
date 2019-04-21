using System;

namespace PhoenixService.ScheduleApp.Dto
{
    public class GetSpecialistScheduleM
    {
        /// <summary>
        /// ID Специалиста
        /// </summary>
        public string SpecialistId { get; set; }
        /// <summary>
        /// ID запроса, сформировавшего дозвон
        /// </summary>
        public string RequestId { get; set; }
        /// <summary>
        /// Желаемая дата приема
        /// </summary>
        public DateTime WantedDate { get; set; }
    }
}