﻿namespace PhoenixService.ScheduleApp.Dto
{
    public class TakeAppointmentM
    {
        /// <summary>
        /// ID запроса, сформировавшего дозвон
        /// </summary>
        public string RequestId { get; set; }
        ///// <summary> TODO
        ///// ID Специалиста
        ///// </summary>
        //public string SpecialistId { get; set; }
        ///// <summary>
        ///// Желаемое время начала приема (с датой)
        ///// </summary>
        //public DateTime AppointmentDateTime { get; set; }
        /// <summary>
        /// ID приема, на который хотим записать
        /// </summary>
        public string AppointmentId { get; set; }
    }
}