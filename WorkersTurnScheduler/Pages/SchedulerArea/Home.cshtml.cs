using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WorkersTurnScheduler.Pages.SchedulerArea
{
    /// <summary>
    /// Class <c>HomeModel</c> contains data and functions needed to render and 
    /// manage the home page
    /// </summary>
    public class HomeModel : PageModel
    {
        /// <value>
        /// User name field. 
        /// </value>
        private string userName = "user" ;

        /// <value>
        /// User name property.
        /// </value>
        public string UserName { get => userName; private set => userName = value; }

        /// <summary>
        /// Page get function.
        /// </summary>
        public void OnGet()
        {
            UserName = "Pedro Pedroso";
        }
    }
}
