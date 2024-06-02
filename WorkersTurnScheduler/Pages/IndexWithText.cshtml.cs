using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WorkersTurnScheduler.Pages
{
    public class IndexWithTextModel : PageModel
    {
        public void OnGet()
        {
            ViewData["Message"] = "Hello world";
        }
    }
}
