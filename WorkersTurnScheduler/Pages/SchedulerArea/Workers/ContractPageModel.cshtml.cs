using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkersTurnScheduler.Domain;
using WorkersTurnScheduler.Services;

namespace WorkersTurnScheduler.Pages.SchedulerArea.Workers
{
    public class ContractModel(IWorkerRepository workerRepository) : PageModel
    {
        private IWorkerRepository _repository { get; set; } = workerRepository;

        public Contract? _contract { get; private set; }

        public String _workerName { get; private set; } = "";

        public String _workerSurname { get; private set; } = "";

        public IActionResult OnGet(UInt128 workerId)
        {
            var worker = _repository.GetWorker(workerId);

            if (worker == null)
            {
                return Error();
            }

            _workerName = worker.Name;
            _workerSurname = worker.Surname;
            _contract = worker.Contract;

            if (_contract == null)
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
