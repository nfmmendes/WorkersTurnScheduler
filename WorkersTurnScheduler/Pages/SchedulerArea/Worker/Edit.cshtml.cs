using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkersTurnScheduler.Domain;
using WorkersTurnScheduler.Services;

namespace WorkersTurnScheduler.Pages.SchedulerArea.Worker
{
    public class EditModel : PageModel
    {
        private IWorkerRepository _repository;

        [BindProperty]
        public Domain.Worker? Worker { get; set; }

        public EditModel(IWorkerRepository repository)
        {
            _repository = repository;
        }

        public IActionResult OnGet(Guid workerId)
        {
            Worker = _repository.GetWorker(workerId);

            if (Worker == null)
            {
                return RedirectToPage("../Error");
            }

            return Page();
        }

    }
}
