using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WorkersTurnScheduler.Pages
{
    /// <summary>
    /// Class <c>IndexWithTextModel</c> contains data and functions to 
    /// manage the index page with a default text. 
    /// </summary>
    public class IndexWithTextModel : PageModel
    {
        /// <summary>
        /// Page get function. 
        /// </summary>
        public void OnGet()
        {
            ViewData["Message"] = "Hello world";
        }
    }
}
