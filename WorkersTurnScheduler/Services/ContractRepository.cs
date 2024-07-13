using WorkersTurnScheduler.Domain;
using WorkersTurnScheduler.Model;

namespace WorkersTurnScheduler.Services
{
    /// <summary>
    /// Class <c>ContractRepository</c> holds the functions needed to
    /// access contract data on database. 
    /// </summary>
    public class ContractRepository : IContractRepository
    {
        /// <value>
        /// The database context.
        /// </value>
        SchedulerContext _context;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="workerRepository"> Worker repository passed as injected dependence. </param>
        public ContractRepository(SchedulerContext context) {
            _context = context;
        }

        /// <summary>
        /// Get the contract by contract id.
        /// </summary>
        /// <param name="contractId">The contract id. </param>
        /// <returns> Return a contract, if the contract exists, null otherwise.</returns>
        public Contract? getContract(Guid contractId)
        {
            return _context.Contracts.FirstOrDefault(x => x.Id == contractId);
        }
    }
}
