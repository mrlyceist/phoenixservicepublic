﻿using PhoenixService.Data.Interfaces;
using PhoenixService.ScheduleApp;
using System;
using System.Configuration;

namespace PhoenixService.Web.ScheduleApi.Configuration
{
    public class Configuration : IApiConfig, IAppConfig, IDataConfiguration
    {
        public Configuration()
        {
            PatientName = ConfigurationManager.AppSettings["PatientName"];
            DepartmentIndex = ConfigurationManager.AppSettings["DepartmentIndex"];
            DoctorIndex = ConfigurationManager.AppSettings["DoctorIndex"];
            EspecialListIndex = ConfigurationManager.AppSettings["EspecialListIndex"];
            TaskInitializeType = int.Parse(ConfigurationManager.AppSettings["TaskInitializeType"]);
            OperatorIndex = ConfigurationManager.AppSettings["OperatorIndex"];
            ScenarioId = Guid.Parse(ConfigurationManager.AppSettings["ScenarioId"]);
            CampaignId = ConfigurationManager.AppSettings["CampaignId"];
            PatientFullName = ConfigurationManager.AppSettings["PatientFullName"];
            Tag = ConfigurationManager.AppSettings["Tag"];
            DefaultDutyComment = ConfigurationManager.AppSettings["DefaultDutyComment"];
            PhoenixDbPath = ConfigurationManager.AppSettings["PhoenixDbPath"];
            IsProdiction = bool.Parse(ConfigurationManager.AppSettings["IsProduction"]);
        }

        public string PatientName { get; }
        public string DepartmentIndex { get; }
        public string DoctorIndex { get; }
        public string EspecialListIndex { get; }
        public int TaskInitializeType { get; }
        public string OperatorIndex { get; }
        public Guid ScenarioId { get; }
        public string CampaignId { get; }
        public string PatientFullName { get; }
        public string Tag { get; }
        public string PhoenixDbPath { get; }
        public string DefaultDutyComment { get; }
        public bool IsProdiction { get; }
    }
}