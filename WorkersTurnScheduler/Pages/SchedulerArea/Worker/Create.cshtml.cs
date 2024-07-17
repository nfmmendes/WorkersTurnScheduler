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
        /// <returns></returns>
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost() {

            if (!HasContract)
                Worker.Contract = null;

            _repository.AddWorker(Worker);
            
            return RedirectToPage("./List");
        }
    }
}