using Microsoft.AspNetCore.Mvc;
using WorkersTurnScheduler.Domain;

namespace WorkersTurnScheduler.Services
{
    public class WorkerRepository : IWorkerRepository
    {
        private List<Worker> Workers 
        {
            get => new List<Worker>{
                                                    new Worker("Paulo", "Pessoa"),
                                                    new Worker("Carlos", "Silva"),
                                                    new Worker("Alan", "Carvalho"),
                                                    new Worker("Rodrigo", "Ribeiro") };
        }

        public List<Worker> GetAllWorkers()
        {
            return Workers;
        }
    }
}
