﻿using Microsoft.Extensions.Logging;
using NCore.Specifications;
using NCore.Specifications.Services;
using PhoenixService.Data.Interfaces.Factories;
using PhoenixService.Data.Interfaces.Resolvers;
using PhoenixService.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PhoenixService.Data.Resolvers
{
    public class AppointmentsResolver : IAppointmentsResolver
    {
        private readonly IIVoiceDuty iVoiceDuty;
        private readonly IAppointmentFactory appointmentFactory;
        private readonly ISpecialistResolver specialistResolver;
        private readonly IScheduleService scheduleService;
        private readonly ILogger logger;

        public AppointmentsResolver(IIVoiceDuty iVoiceDuty,
            IAppointmentFactory appointmentFactory,
            ISpecialistResolver specialistResolver,
            IScheduleService scheduleService,
            ILogger logger)
        {
            this.iVoiceDuty = iVoiceDuty;
            this.appointmentFactory = appointmentFactory;
            this.specialistResolver = specialistResolver;
            this.scheduleService = scheduleService;
            this.logger = logger;
        }

        public Task<Appointment[]> GetNearestByRequestId(string requestId)
        {
            var clientCallReason = iVoiceDuty.GetClientCallReason(requestId);
            var doctorId = iVoiceDuty.GetDoctor(clientCallReason);
            var depth = iVoiceDuty.GetSeekDepth(clientCallReason);
            var length = iVoiceDuty.GetVisitLenght(clientCallReason);

            logger.LogDebug($"Loaded ClientCallReason from phoenix: {@clientCallReason}\r\n" +
                            $"{nameof(doctorId)}: {doctorId}\r\n" +
                            $"{nameof(depth)}: {@depth}\r\n" +
                            $"{nameof(length)}: {length}");

            var specialist = specialistResolver.GetByPhoenixId(doctorId);
            if (specialist == null)
                throw new Exception($"Specialist not found for request {requestId}");

            var duties = iVoiceDuty.OfferTime(clientCallReason.ClientCode, doctorId, length, depth);

            var appointments = duties
                .Select(d => appointmentFactory.Create(d.StartTime, d.EndTime, specialist, null, d.Index))
                .ToArray();

            return Task.FromResult(appointments);
        }

        public Task<bool> TryTakeAppointment(string appointmentId, string requestId)
        {
            var ccr = iVoiceDuty.GetClientCallReason(requestId);
            var patientId = ccr.ClientCode;

            try
            {
                scheduleService.OccupyReception(appointmentId, patientId);
                return Task.FromResult(true);
            }
            catch (Exception e)
            {
                // TODO: залогировать и пробросить вверх
                return Task.FromResult(false);
            }
        }
    }
}