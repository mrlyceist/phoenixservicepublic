using System;

namespace PhoenixService.Domain
{
    public class SpecialTask
    {
        public string PhoenixId { get; set; }
        public string PatientName { get; set; }
        public DateTime DateIn { get; set; }
        public int InitializeType { get; set; }
        public string EspecialListPhoenixId { get; set; }
        public string OperatorPhoenixId { get; set; }
        public string DepartmentPhoenixId { get; set; }
        public DateTime StartTime { get; set; }
        public string DoctorPhoenixId { get; set; }
    }
}