using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkersTurnScheduler.Domain;
using WorkersTurnScheduler.Model;

namespace WorkersTurnScheduler.Services
{
    /// <summary>
    /// Class <c>WorkerRepository</c> contains the functions needed
    /// to access workers data. 
    /// </summary>
    public class WorkerRepository : IWorkerRepository
    {
        private SchedulerContext _context;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context">The scheduler context</param>
        public WorkerRepository(SchedulerContext context)
        {
           _context = context;
            if (_context.Workers.Count() == 0)
            {
                _context.Workers.AddRange(new List<Worker>{
                    new Worker("Paulo", "Pessoa", new Contract(ContractType.Regular, new Tuple<int, int>(20, 40), new Tuple<int, int>(3, 5), new Tuple<int, int>(3, 8) )),
                    new Worker("Carlos", "Silva", new Contract(ContractType.Regular, new Tuple<int, int>(30, 40), new Tuple<int, int>(4, 5), new Tuple<int, int>(6, 8) )),
                    new Worker("Alan", "Carvalho",new Contract(ContractType.Freelance, new Tuple<int, int>(20, 40), new Tuple<int, int>(1, 3), new Tuple<int, int>(4, 6) ) ),
                    new Worker("Rodrigo", "Ribeiro", new Contract(ContractType.Temporary, new Tuple<int, int>(40, 40), new Tuple<int, int>(5, 5), new Tuple<int, int>(8, 8) )) });
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// Get the worker list.
        /// </summary>
        /// <returns>The list of workers.</returns>
        public List<Worker> GetAllWorkers()
        {
            return _context.Workers.ToList();
        }

        /// <summary>
        /// Get the worker with the respective id. 
        /// </summary>
        /// <param name="id">The worker id.</param>
        /// <returns>A worker, if it is found. Null otherwise.</returns>
        public Worker? GetWorker(Guid id)
        {
            return _context.Workers.Include(x => x.Contract).FirstOrDefault(x=> x.Id == id);
        }


        /// <summary>
        /// Add a new worker in the repository
        /// </summary>
        /// <param name="worker"> The new worker</param>
        public void AddWorker(Worker worker)
        {
            _context.Workers.Add(worker);
            _context.SaveChanges();
        }
    }
}
