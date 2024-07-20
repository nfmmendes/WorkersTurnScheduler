using WorkersTurnScheduler.Domain;

namespace WorkersTurnScheduler.Services
{
    /// <summary>
    /// ContractRepository inteface.
    /// </summary>
    public interface IContractRepository
    {
        /// <summary>
        /// Get the contract by contract id.
        /// </summary>
        /// <param name="contractId">The contract id. </param>
        /// <returns> Return a contract, if the contract exists, null otherwise.</returns>
        public Contract? getContract(Guid contractId);

        /// <summary>
        /// Update a contract.
        /// </summary>
        /// <param name="id"> The contract id</param>
        /// <param name="contract"> The object with the new contract data.</param>
        public void updateContract(Guid id, Contract contract);

        /// <summary>
        /// Remove a contract from the repository
        /// </summary>
        /// <param name="id"> The id of the contract to be remved </param>
        public void removeContract(Guid id);
    }
}
