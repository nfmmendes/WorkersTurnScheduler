using Microsoft.AspNetCore.Mvc;
using WorkersTurnScheduler.Domain;

namespace WorkersTurnScheduler.Services
{
    public class WorkerRepository : IWorkerRepository
    {
        private static List<Worker> Workers 
        {
            get
            {
                Worker.ResetId();
                Contract.ResetId();
                return new List<Worker>{
                                                    new Worker("Paulo", "Pessoa", new Contract(ContractType.Regular, new Tuple<int, int>(20, 40), new Tuple<int, int>(3, 5), new Tuple<int, int>(3, 8) )),
                                                    new Worker("Carlos", "Silva", new Contract(ContractType.Regular, new Tuple<int, int>(30, 40), new Tuple<int, int>(4, 5), new Tuple<int, int>(6, 8) )),
                                                    new Worker("Alan", "Carvalho",new Contract(ContractType.Freelance, new Tuple<int, int>(20, 40), new Tuple<int, int>(1, 3), new Tuple<int, int>(4, 6) ) ),
                                                    new Worker("Rodrigo", "Ribeiro", new Contract(ContractType.Temporary, new Tuple<int, int>(40, 40), new Tuple<int, int>(5, 5), new Tuple<int, int>(8, 8) )) };
            }
        }

        public List<Worker> GetAllWorkers()
        {
            return Workers;
        }

        public Worker? GetWorker(UInt128 id)
        {
            return Workers.FirstOrDefault(x=> x.Id == id);
        }
    }
}
