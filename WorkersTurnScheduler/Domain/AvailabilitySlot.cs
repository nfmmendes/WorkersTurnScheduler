using System.ComponentModel.DataAnnotations;

namespace WorkersTurnScheduler.Domain
{
    public class AvailabilitySlot
    {
        [Required]
        List<DayOfWeek> WeekDays { get; set; }

        [Required]
        [Range(1, 53)]
        int InitialWeekIndex { get; set; }

        [Range(1, 53)]
        int FinalWeekIndex { get; set; }

        [Required]
        public TimeOnly Start { get; set; }

        [Required]
        public TimeOnly End { get; set; }

        private AvailabilitySlot() { }
    }
}
