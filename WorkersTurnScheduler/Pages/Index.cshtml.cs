using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WorkersTurnScheduler.Pages
{
    /// <summary>
    /// Class <c>IndexModel</c> contains the data and structure to handle the initial page.
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <value>
        /// The logger object.
        /// </value>
        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// Constructor. 
        /// </summary>
        /// <param name="logger"> Logger passed as injected dependence. </param>
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// The get fucntion.
        /// </summary>
        public void OnGet()
        {

        }
    }
}
