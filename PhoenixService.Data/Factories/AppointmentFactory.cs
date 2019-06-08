using PhoenixService.Data.Interfaces.Factories;
using PhoenixService.Domain;
using System;
using Patient = PhoenixService.Domain.Patient;

namespace PhoenixService.Data.Factories
{
    public class AppointmentFactory : IAppointmentFactory
    {
        public Appointment Build(DateTime dateTimeStart,
            DateTime dateTimeEnd,
            Specialist specialist = null,
            Patient patient = null,
            string phoenixId = null)
        {
            return new Appointment
            {
                PhoenixId = phoenixId,
                Patient = patient,
                Specialist = specialist,
                DateTimeStart = dateTimeStart,
                DateTimeEnd = dateTimeEnd
            };
        }
    }
}