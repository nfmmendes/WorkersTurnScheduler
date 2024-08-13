using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkersTurnScheduler.Services;
using WorkersTurnScheduler.Domain;

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
        private IWorkerRepository _repository;

        /// <value>
        /// Property that is used to control if the worker has a contract or not. 
        /// </value>
        [BindProperty]
        public bool HasContract { get; set; }

        /// <value>
        /// Hold the worker data to be inserted in the repository. 
        /// </value>
        [BindProperty]
        public Domain.Worker Worker { get; set; } = new Domain.Worker();

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
        /// <returns>The page view</returns>
        public IActionResult OnGet()
        {
            return Page();
        }

        /// <summary>
        /// Page post function. 
        /// </summary>
        /// <returns>A redirection to the worker list page.</returns>
        public IActionResult OnPost() {

            if (!HasContract)
                Worker.Contract = null;

            _repository.AddWorker(Worker);
            
            return RedirectToPage("./List");
        }
    }
}