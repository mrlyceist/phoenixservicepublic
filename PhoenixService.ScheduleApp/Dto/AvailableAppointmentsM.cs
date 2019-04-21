using System;

namespace PhoenixService.ScheduleApp.Dto
{
    public class AvailableAppointmentsM
    {
        /// <summary>
        /// ID Специалиста
        /// </summary>
        public string SpecialistId { get; set; }
        /// <summary>
        /// Доступные приемы (время начала приема) - максимум 5
        /// </summary>
        public DateTime[] AvailableAppointments { get; set; }
    }
}