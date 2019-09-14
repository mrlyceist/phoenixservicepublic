using PhoenixService.Data.Interfaces;
using PhoenixService.ScheduleApp;
using System;
using System.Configuration;

namespace PhoenixService.Web.ScheduleApiOld
{
    public class Configuration : IAppConfig, IDataConfiguration
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
            PhoenixExecutablePath = ConfigurationManager.AppSettings["PhoenixExecutablePath"];
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
        public string PhoenixExecutablePath { get; }
        public string DefaultDutyComment { get; }
    }
}