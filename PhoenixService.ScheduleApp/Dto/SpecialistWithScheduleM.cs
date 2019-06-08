using System;

namespace PhoenixService.ScheduleApp.Dto
{
    public class SpecialistWithScheduleM
    {
        ///// <summary> TODO
        ///// ID Специалиста
        ///// </summary>
        //public string SpecialistId { get; set; }
        /// <summary>
        /// Специальность
        /// </summary>
        public string Speciality { get; set; }
        /// <summary>
        /// Имя специалиста (по возможности - ФИО)
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Дата ближайшего доступного для записи приема
        /// </summary>
        public DateTime NearestFreeAppointmentDate { get; set; }
    }
}