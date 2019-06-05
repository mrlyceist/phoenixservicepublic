using NCore;
using NCore.Models;
using NCore.Specifications.Factories;
using NCore.Specifications.Services;
using PhoenixService.Data.Interfaces;
using PhoenixService.Data.Interfaces.Resolvers;
using PhoenixService.Domain;
using System;

namespace PhoenixService.Data.Resolvers
{
    public class AppointmentsResolver : IAppointmentsResolver
    {
        private readonly IDataConfiguration configuration;
        private readonly IFoxDbInteractor dbInteractor;
        private readonly IScheduleService scheduleService;
        private readonly IEntityFactory<Duty> dutyFactory;

        public AppointmentsResolver(IFoxDbInteractor dbInteractor,
            IDataConfiguration configuration, IScheduleService scheduleService, IEntityFactory<Duty> dutyFactory)
        {
            this.dbInteractor = dbInteractor;
            this.configuration = configuration;
            this.scheduleService = scheduleService;
            this.dutyFactory = dutyFactory;
        }

        public Appointment[] GetNearestByRequestId(string requestId)
        {
            dbInteractor.InitializeConnection(configuration.PhoenixExecutablePath);

            //var wat =
            return Array.Empty<Appointment>();
        }
    }
}