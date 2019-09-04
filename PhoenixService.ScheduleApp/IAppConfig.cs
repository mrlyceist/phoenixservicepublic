using System;

namespace PhoenixService.ScheduleApp
{
    public interface IAppConfig
    {
        string PatientName { get; set; }
        string DepartmentIndex { get; set; }
        string DoctorIndex { get; set; }
        string EspecialListIndex { get; set; }
        int TaskInitializeType { get; set; }
        string OperatorIndex { get; set; }
        Guid ScenarioId { get; set; }
        string CompaignId { get; set; }
        string PatientFullName { get; set; }
        string Tag { get; set; }
    }
}