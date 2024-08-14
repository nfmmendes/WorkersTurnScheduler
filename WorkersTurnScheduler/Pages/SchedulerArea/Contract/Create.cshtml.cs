using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkersTurnScheduler.Model;
using WorkersTurnScheduler.Services;

namespace WorkersTurnScheduler.Pages.SchedulerArea.Contract
{
    /// <summary>
    /// Class <c>CreateModel</c> is a page model class that
    /// holds that and methods to render the contract create page. 
    /// </summary>
    public class CreateModel : PageModel
    {
        /// <value>
        /// Contract's repository.
        /// </value>
        private IContractRepository _repository;

        /// <value>
        /// Hold the contract data to be inserted in the repository. 
        /// </value>
        [BindProperty]
        public Domain.Contract Contract {  get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">Contract repository, injected as a dependence.</param>
        public CreateModel(IContractRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Page get function.
        /// </summary>
        /// <returns>The page view</returns>
        public IActionResult OnGet()
        {
            HttpContext.Request.RouteValues.TryGetValue("workerId", out object workerIdObject);

            if (workerIdObject == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
