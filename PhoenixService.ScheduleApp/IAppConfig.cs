using System;

namespace PhoenixService.ScheduleApp
{
    public interface IAppConfig
    {
        string PatientName { get; }
        string DepartmentIndex { get; }
        string DoctorIndex { get; }
        string EspecialListIndex { get; }
        int TaskInitializeType { get; }
        string OperatorIndex { get; }
        Guid ScenarioId { get; }
        string CampaignId { get; }
        string PatientFullName { get; }
        string Tag { get; }
    }
}