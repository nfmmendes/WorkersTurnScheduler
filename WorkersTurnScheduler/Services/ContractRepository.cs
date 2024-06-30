using WorkersTurnScheduler.Domain;

namespace WorkersTurnScheduler.Services
{
    /// <summary>
    /// Class <c>ContractRepository</c> holds the functions needed to
    /// access contract data on database. 
    /// </summary>
    public class ContractRepository : IContractRepository
    {
        /// <value>
        /// Workers repository
        /// </value>
        IWorkerRepository _workerRepository;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="workerRepository"> Worker repository passed as injected dependence. </param>
        public ContractRepository(IWorkerRepository workerRepository) { 
            _workerRepository = workerRepository;
        }

       /// <summary>
       /// Get the contract by contract id.
       /// </summary>
       /// <param name="contractId">The contract id. </param>
       /// <returns> Return a contract, if the contract exists, null otherwise.</returns>
        public Contract? getContract(UInt128 contractId)
        {
            // TODO: Search it directly on Contract list when it will be available.
            var worker = _workerRepository.GetAllWorkers().FirstOrDefault(worker => worker.Contract.Id == contractId);

            if (worker != null)
                return worker.Contract;
            return null;
        }

    }
}
