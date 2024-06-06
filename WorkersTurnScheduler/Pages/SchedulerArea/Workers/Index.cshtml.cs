using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkersTurnScheduler.Domain;
using WorkersTurnScheduler.Services;

namespace WorkersTurnScheduler.Pages.SchedulerArea.Workers
{
    public class WorkersListModel : PageModel
    {
        public List<Worker> Workers { get; private set; }

        public IWorkerRepository _repository { get; private set; }

        public WorkersListModel(IWorkerRepository repository)
        {
            _repository = repository;
            Workers = new List<Worker>();
        }

        public void OnGet()
        {
            Workers = _repository.GetAllWorkers();
        }
    }
}
