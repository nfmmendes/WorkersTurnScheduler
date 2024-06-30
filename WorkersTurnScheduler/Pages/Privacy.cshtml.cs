using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WorkersTurnScheduler.Pages
{
    /// <summary>
    /// Class <c>PrivateModel</c> includes the data and functions to 
    /// manage the privacy page.
    /// </summary>
    public class PrivacyModel : PageModel
    {
        /// <value>
        /// The logger object.
        /// </value>
        private readonly ILogger<PrivacyModel> _logger;

        /// <summary>
        /// Constructor. 
        /// </summary>
        /// <param name="logger">The log object.</param>
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

    }

}
