using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WorkersTurnScheduler.Pages.SchedulerArea
{
    public class HomeModel : PageModel
    {
        private string userName = "user" ;

        public string UserName { get => userName; private set => userName = value; }

        public void OnGet()
        {
            UserName = "Pedro Pedroso";
        }
    }
}
