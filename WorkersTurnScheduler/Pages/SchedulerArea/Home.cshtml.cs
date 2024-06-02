using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WorkersTurnScheduler.Pages.SchedulerArea
{
    public class HomeModel : PageModel
    {
        public string UserName { get; private set; }

        public void OnGet()
        {
            UserName = "Pedro Pedroso";
        }
    }
}
