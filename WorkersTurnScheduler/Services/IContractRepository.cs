using WorkersTurnScheduler.Domain;

namespace WorkersTurnScheduler.Services
{
    /// <summary>
    /// ContractRepository inteface
    /// </summary>
    public interface IContractRepository
    {
        /// <summary>
        /// Get the contract by contract id.
        /// </summary>
        /// <param name="contractId">The contract id. </param>
        /// <returns> Return a contract, if the contract exists, null otherwise.</returns>
        public Contract? getContract(UInt128 contractId);
    }
}
