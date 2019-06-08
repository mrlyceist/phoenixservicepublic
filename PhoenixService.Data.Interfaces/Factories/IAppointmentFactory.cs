using PhoenixService.Domain;
using System;

namespace PhoenixService.Data.Interfaces.Factories
{
    public interface IAppointmentFactory
    {
        Appointment Create(DateTime dateTimeStart,
            DateTime dateTimeEnd,
            Specialist specialist = null,
            Patient patient = null,
            string phoenixId = null);
    }
}