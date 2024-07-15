using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkersTurnScheduler.Services;

namespace WorkersTurnScheduler.Pages.SchedulerArea.Worker
{
    /// <summary>
    /// Class <c>CreateModel</c> is a page model class that
    /// holds that and methods to render the worker create page. 
    /// </summary>
    public class CreateModel : PageModel
    {
        /// <value>
        /// Worker's repository.
        /// </value>
        IWorkerRepository _repository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">Worker repository, injected as a dependence.</param>
        public CreateModel(IWorkerRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Page get function.
        /// </summary>
        /// <returns></returns>
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
