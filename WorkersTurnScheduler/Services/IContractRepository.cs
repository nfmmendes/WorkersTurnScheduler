using WorkersTurnScheduler.Domain;

namespace WorkersTurnScheduler.Services
{
    public interface IContractRepository
    {
        public Contract? getContract(UInt128 contractId);
    }
}
