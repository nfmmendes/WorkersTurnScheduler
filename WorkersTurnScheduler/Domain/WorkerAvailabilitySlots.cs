using System.ComponentModel.DataAnnotations;

namespace WorkersTurnScheduler.Domain
{
    /// <summary>
    /// Class <c>WorkerAvailabilitySlots</c> contains the data to represent
    /// the connection between workers and their availability slots. 
    /// </summary>
    public class WorkerAvailabilitySlots
    {
        /// <value>
        /// Worker id.
        /// </value>
        [Key]
        public UInt128 WorkerId { get; private set; } 

        /// <summary>
        /// The list of availability slots to the given worker. 
        /// </summary>
        public List<AvailabilitySlot> AvailabilitySlots { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        private WorkerAvailabilitySlots() { }
    }
}
