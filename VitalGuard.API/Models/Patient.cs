namespace VitalGuard.API.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string RoomNumber { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
