using NCore.Models;
using NCore.Specifications.Factories;
using PhoenixService.Data.Interfaces;
using PhoenixService.Data.Interfaces.Repositories;
using PhoenixService.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace PhoenixService.Data.Repositories
{
    // TODO: Implement (#5, #6)
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly IEntityFactory<Duty> dutyFactory;
        private readonly IDataConfig config;

        public AppointmentRepository(IEntityFactory<Duty> dutyFactory, IDataConfig config)
        {
            this.dutyFactory = dutyFactory;
            this.config = config;
        }

        public IQueryable<Appointment> Query()
        {
            throw new System.NotImplementedException();
        }

        public Task Save(Appointment appointment)
        {
            var duty = new Duty
            {
                Index = appointment.PhoenixId,
                Doctor = appointment.Specialist.PhoenixId,
                StartTime = appointment.DateTimeStart.Value,
                EndTime = appointment.DateTimeEnd.Value,
                Patient = appointment.Patient.PhoenixId,
                Comment = config.DefaultDutyComment
            };

            dutyFactory.StoreIntoDb(duty);

            return Task.CompletedTask;
        }
    }
}