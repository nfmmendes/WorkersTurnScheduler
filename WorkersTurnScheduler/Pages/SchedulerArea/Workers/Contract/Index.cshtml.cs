using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkersTurnScheduler.Domain;
using WorkersTurnScheduler.Services;


namespace WorkersTurnScheduler.Pages.SchedulerArea.Workers.Contract
{
    public class ContractModel(IWorkerRepository workerRepository) : PageModel
    {
        private IWorkerRepository _repository { get; set; } = workerRepository;

        public Domain.Contract? Contract { get; private set; }

        public string WorkerName { get; private set; } = "";

        public string WorkerSurname { get; private set; } = "";

        [BindProperty]
        public UInt128 WorkerId { get; set; }

        public IActionResult OnGet()
        {
            HttpContext.Request.RouteValues.TryGetValue("workerId", out object workerIdObject);

            WorkerId = System.Convert.ToUInt64(workerIdObject);

            var worker = _repository.GetWorker(WorkerId);

            if (worker == null)
            {
                return Error();
            }

            WorkerName = worker.Name;
            WorkerSurname = worker.Surname;
            Contract = worker.Contract;

            if (Contract == null)
            {
                return Error();
            }

            return Page();
        }

        private IActionResult Error()
        {
            return RedirectToPage("./../../Error");
        }
    }
}
