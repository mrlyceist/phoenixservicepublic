using PhoenixService.ScheduleApp.Dto;
using PhoenixService.ScheduleApp.Specifications.Actions;
using System;
using System.Threading.Tasks;

namespace PhoenixService.ScheduleApp.Actions
{
    public class ScheduleAction : IScheduleAction
    {
        public Task<SpecialistWithScheduleM> GetNearestAppointments(string requestId)
        {
            var nextAppointment = new SpecialistWithScheduleM
            {
                Name = "Чехов Антон Павлович",
                SpecialistId = "C0ECF9D8-5DAA-43C0-B255-5DD52884A0CD",
                Speciality = "Специалист широкого профиля",
                NearestFreeAppointmentDate = new DateTime(2019, 5, 1),
            };

            return Task.FromResult(nextAppointment);
        }

        public Task<AvailableAppointmentsM> GetAvailableAppointments(GetSpecialistScheduleM getSpecialistScheduleM)
        {
            var appointments = new AvailableAppointmentsM
            {
                SpecialistId = "C0ECF9D8-5DAA-43C0-B255-5DD52884A0CD",
                AvailableAppointments = new[]
                {
                    new DateTime(2019, 5, 1, 11, 30, 0),
                    new DateTime(2019, 5, 1, 13, 45, 0),
                    new DateTime(2019, 5, 2, 11, 30, 0),
                    new DateTime(2019, 5, 3, 9, 30, 0),
                }
            };

            return Task.FromResult(appointments);
        }
    }
}