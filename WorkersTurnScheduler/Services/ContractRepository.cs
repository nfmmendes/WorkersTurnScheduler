using WorkersTurnScheduler.Domain;

namespace WorkersTurnScheduler.Services
{
    public class ContractRepository : IContractRepository
    {
        IWorkerRepository _workerRepository;
        public ContractRepository(IWorkerRepository workerRepository) { 
            _workerRepository = workerRepository;
        }

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
