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

        /// <summary>
        /// Add a new worker in the repository
        /// </summary>
        /// <param name="worker"> The new worker</param>
        void AddWorker(Worker worker);

        /// <summary>
        /// Remove a worker in the repository
        /// </summary>
        /// <param name="workerId">The worker id</param>
        void RemoveWorker(Guid workerId);
    }
}
