using System.ComponentModel.DataAnnotations;

namespace WorkersTurnScheduler.Domain
{
    /// <summary>
    /// Class <c> AvailabilitySlot </c> models the worker time slot availability during a 
    /// set of days and weeks. 
    /// </summary>
    public class AvailabilitySlot
    {
        /// <value>
        /// The availabilitySlot id.
        /// </value>
        [Required, Key]
        public Guid Id { get; private set; }

        /// <value>
        /// The week days in which the worker is available. 
        /// </value>
        [Required]
        List<DayOfWeek> WeekDays { get; set; }

        /// <value>
        /// The availability slot first week index.
        /// </value>
        [Required]
        [Range(1, 53)]
        int InitialWeekIndex { get; set; }

        /// <value>
        /// The availability slot last week index.
        /// </value>
        [Range(1, 53)]
        int FinalWeekIndex { get; set; }

        /// <value>
        /// The slot start time.
        /// </value>
        [Required]
        public TimeOnly Start { get; set; }

        /// <value>
        /// The slot end time
        /// </value>
        [Required]
        public TimeOnly End { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        private AvailabilitySlot() { 
        }
    }
}
