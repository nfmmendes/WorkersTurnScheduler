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

        /// <summary>
        /// Update a contract.
        /// </summary>
        /// <param name="id"> The contract id</param>
        /// <param name="contract"> The object with the new contract data.</param>
        public void updateContract(Guid id, Contract contract) {
            var newContract = getContract(id);
            if (newContract == null)
                return;

            newContract.ContractType = contract.ContractType;
            newContract.MinWeeklyHours = contract.MinWeeklyHours;
            newContract.MaxWeeklyHours = contract.MaxWeeklyHours;
            newContract.MinDailyHours = contract.MinDailyHours;
            newContract.MaxDailyHours = contract.MaxDailyHours;
            newContract.MinWeeklyDays = contract.MinWeeklyDays;
            newContract.MaxWeeklyDays = contract.MaxWeeklyDays;

            _context.Contracts.Update(newContract);
            _context.SaveChanges();
        }

        /// <summary>
        /// Remove a contract from the repository
        /// </summary>
        /// <param name="id"> The id of the contract to be remved </param>
        public void removeContract(Guid id)
        {
            var contract = _context.Contracts.FirstOrDefault(x=>x.Id == id);

            if(contract != null)
            {
                _context.Contracts.Remove(contract);
                _context.SaveChanges();
            }
        }
    }
}
