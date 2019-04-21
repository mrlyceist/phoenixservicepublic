using PhoenixService.ScheduleApp.Dto;
using System;
using System.Threading.Tasks;
using PhoenixService.ScheduleApp.Specifications.Actions;

namespace PhoenixService.ScheduleApp.Actions
{
    public class AppointmentsAction : IAppointmentsAction
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
    }
}