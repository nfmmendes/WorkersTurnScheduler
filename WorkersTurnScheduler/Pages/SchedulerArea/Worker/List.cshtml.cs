using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;
using WorkersTurnScheduler.Domain;
using WorkersTurnScheduler.Services;

namespace WorkersTurnScheduler.Pages.SchedulerArea.Worker
{
    /// <summary>
    /// Class <c>WorkersListModel</c> contains data and functions needed to render and 
    /// manage the workers list page. 
    /// </summary>
    public class WorkersListModel : PageModel
    {
        /// <value>
        /// The workers list. 
        /// </value>
        public List<Domain.Worker> Workers { get; private set; }

        /// <value>
        /// Worker repository.
        /// </value>
        public IWorkerRepository _repository { get; private set; }

        /// <summary>
        /// Constructor. 
        /// </summary>
        /// <param name="repository">Worker repository passed as injected dependency.</param>
        public WorkersListModel(IWorkerRepository repository)
        {
            _repository = repository;
            Workers = new List<Domain.Worker>();
        }

        /// <summary>
        /// Page get function.
        /// </summary>
        public void OnGet()
        {
            Workers = _repository.GetAllWorkers();
        }

        /// <summary>
        /// Handler to delete a worker
        /// </summary>
        /// <param name="workerId"> The worker id</param>
        /// <returns> The result of redirection to the page itself </returns>
        public IActionResult OnPostDelete(Guid workerId)
        {
            _repository.RemoveWorker(workerId);

            return RedirectToPage("./List");
        }
    }
}
