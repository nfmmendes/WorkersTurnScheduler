using WorkersTurnScheduler.Domain;

namespace WorkersTurnScheduler.Services
{
    /// <summary>
    /// WorkerRepository interface.
    /// </summary>
    public interface IWorkerRepository
    {
        /// <summary>
        /// Get a list with all the workers. 
        /// </summary>
        /// <returns>A list of workers. </returns>
        List<Worker> GetAllWorkers(); 

        /// <summary>
        /// Get a worker. 
        /// </summary>
        /// <param name="id">The worker id.</param>
        /// <returns>A worker. </returns>
        Worker? GetWorker(Guid id);
    }
}
