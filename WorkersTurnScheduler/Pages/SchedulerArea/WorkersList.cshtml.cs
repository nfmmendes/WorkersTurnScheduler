using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkersTurnScheduler.Domain;

namespace WorkersTurnScheduler.Pages.SchedulerArea
{
    public class WorkersListModel : PageModel
    {
        public List<Worker> Workers { get => new List<Worker>{ 
                                                    new Worker("Paulo", "Pessoa"),
                                                    new Worker("Carlos", "Silva"), 
                                                    new Worker("Alan", "Carvalho"), 
                                                    new Worker("Rodrigo", "Ribeiro") }; }

        public void OnGet()
        {
        }
    }
}
