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
                return new List<Worker>{
                                                    new Worker("Paulo", "Pessoa"),
                                                    new Worker("Carlos", "Silva"),
                                                    new Worker("Alan", "Carvalho"),
                                                    new Worker("Rodrigo", "Ribeiro") };
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
