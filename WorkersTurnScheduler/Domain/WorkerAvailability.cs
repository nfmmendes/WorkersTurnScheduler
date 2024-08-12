using System.ComponentModel.DataAnnotations;

namespace WorkersTurnScheduler.Domain
{
    /// <summary>
    /// Class <c>WorkerAvailability</c> contains the data to represent
    /// the connection between workers and their availability slots. 
    /// </summary>
    public class WorkerAvailability
    {
        /// <value>
        /// The WorkerAvailabilitySlots id. 
        /// </value>
        [Required, Key]
        public Guid Id { get; private set; }

        /// <value>
        /// The worker.
        /// </value>
        [Key]
        public Worker Worker { get; private set; } = new Worker(); 

        /// <summary>
        /// The list of availability slots to the given worker. 
        /// </summary>
        public List<AvailabilitySlot> AvailabilitySlots { get; private set; } = new List<AvailabilitySlot>();

        /// <summary>
        /// Constructor.
        /// </summary>
        public WorkerAvailability() { 
        }
    }
}
