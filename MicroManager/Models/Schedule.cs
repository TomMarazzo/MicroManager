namespace MicroManager.Models
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public bool Soak  { get; set; }
        public bool Sow { get; set; }
        public bool Blackout { get; set; }
        public bool Uncover { get; set; }
        public bool Harvest { get; set; }


    }
}
