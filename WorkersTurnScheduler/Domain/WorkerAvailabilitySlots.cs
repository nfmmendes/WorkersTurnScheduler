using System.ComponentModel.DataAnnotations;

namespace WorkersTurnScheduler.Domain
{
    public class WorkerAvailabilitySlots
    {
        [Key]
        public UInt128 WorkerId { get; private set; } 

        public List<AvailabilitySlot> AvailabilitySlots { get; private set; }

        private WorkerAvailabilitySlots() { }
    }
}
