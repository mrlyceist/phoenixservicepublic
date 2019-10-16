using NCore.Models;
using NCore.Specifications.Factories;
using PhoenixService.Data.Interfaces;
using PhoenixService.Data.Interfaces.Repositories;
using PhoenixService.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PhoenixService.Data.Repositories
{
    // TODO: Implement (#5, #6)
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly IEntityFactory<Duty> dutyFactory;
        private readonly IDataConfiguration config;

        public AppointmentRepository(IEntityFactory<Duty> dutyFactory, IDataConfiguration config)
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
            var duty = dutyFactory.GetFromDb(appointment.PhoenixId);
            if (duty == null)
                throw new Exception($"Duty {appointment.PhoenixId} is not found");

            duty.Patient = appointment.Patient.PhoenixId;

            dutyFactory.StoreIntoDb(duty);

            return Task.CompletedTask;
        }
    }
}