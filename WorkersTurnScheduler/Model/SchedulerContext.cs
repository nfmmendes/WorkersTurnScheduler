using Microsoft.EntityFrameworkCore;
using WorkersTurnScheduler.Domain;

namespace WorkersTurnScheduler.Model
{
    /// <summary>
    /// Class <c>SchedulerContext</c> contains the scheduler
    /// data. 
    /// </summary>
    public class SchedulerContext : DbContext
    {
        /// <value>
        /// The set of contracts.
        /// </value>
        public DbSet<Contract> Contracts { get; set; }

        /// <value>
        /// The set of workers.
        /// </value>
        public DbSet<Worker> Workers { get; set; }

        /// <value>
        /// The set of worker availability slots.
        /// </value>
        public DbSet<WorkerAvailability> WorkerAvailabilitySlots { get; set; }

        /// <value>
        /// The set of availability slots.
        /// </value>
        public DbSet<AvailabilitySlot> AvailabilitySlots { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="options"> Context options. </param>
        public SchedulerContext(DbContextOptions<SchedulerContext> options)
        : base(options) { }
    }
}
