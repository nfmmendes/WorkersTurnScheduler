using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkersTurnScheduler.Domain;

namespace UnitTests
{
    public class WorkerAvailabilityUnitTests
    {
        [Fact]
        void TestDefaultConstructor()
        {
            WorkerAvailability workerAvailability = new WorkerAvailability();

            Assert.NotNull(workerAvailability);
            Assert.True(workerAvailability.AvailabilitySlots.Count() == 0);
            Assert.True(workerAvailability.Worker != null);
        }
    }
}
