namespace VitalGuard.API.Models
{
    public class VitalSign
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public int HeartRate { get; set; }
        public int BloodPressureSystolic { get; set; }
        public int BloodPressureDiastolic { get; set; }
        public int SpO2 { get; set; }
        public decimal Temperature { get; set; }
        public bool AlertTriggered { get; set; }
        public DateTime RecordedAt { get; set; }
    }
}
