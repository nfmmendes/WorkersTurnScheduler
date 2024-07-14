using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkersTurnScheduler.Services;

namespace WorkersTurnScheduler.Pages.SchedulerArea.Worker
{
    public class IndexModel(IWorkerRepository workerRepository) : PageModel
    {
        private readonly IWorkerRepository _repository = workerRepository;

        /// <value>
        /// Worker id.
        /// </value>
        [BindProperty]
        public Guid WorkerId { get; set; }

        public Domain.Worker Worker { get; private set; }

        public IActionResult OnGet(Guid workerId)
        {
            Worker = _repository.GetWorker(workerId);

            if (Worker == null)
            {
                return Error();
            }

            return Page();
        }

        /// <summary>
        /// The page error function. 
        /// </summary>
        /// <returns></returns>
        private IActionResult Error()
        {
            return RedirectToPage("./../../Error");
        }
    }
}
