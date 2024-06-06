using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkersTurnScheduler.Domain;
using WorkersTurnScheduler.Services;

namespace WorkersTurnScheduler.Pages.SchedulerArea.Workers
{
    public class ContractModel(IWorkerRepository workerRepository) : PageModel
    {
        private IWorkerRepository _repository { get; set; } = workerRepository;

        public Contract? Contract { get; private set; }

        public String WorkerName { get; private set; } = "";

        public String WorkerSurname { get; private set; } = "";

        public IActionResult OnGet(UInt128 workerId)
        {
            var worker = _repository.GetWorker(workerId);

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
