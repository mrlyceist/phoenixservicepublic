namespace PhoenixService.ScheduleApp.Dto
{
    public class AvailableAppointmentsM
    {
        /// <summary>
        /// ID запроса, сформировавшего дозвон
        /// </summary>
        public string RequestId { get; set; }
        /// <summary>
        /// Доступные приемы (время начала приема) - максимум 5
        /// </summary>
        public AppointmentM[] AvailableAppointments { get; set; }
    }
}