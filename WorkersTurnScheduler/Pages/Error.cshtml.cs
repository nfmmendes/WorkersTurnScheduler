using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace WorkersTurnScheduler.Pages
{
    /// <summary>
    /// Class <c>ErrorModel</c> contains data and functions to handle the error page
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        /// <value>
        /// The request id. 
        /// </value>
        public string? RequestId { get; set; }

        /// <summary>
        /// Get if the request id must be shown.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        /// <value>
        /// Logger object.
        /// </value>
        private readonly ILogger<ErrorModel> _logger;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger">The logger object.</param>
        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Page get function.
        /// </summary>
        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}
