using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkersTurnScheduler.Domain;
using WorkersTurnScheduler.Services;


namespace WorkersTurnScheduler.Pages.SchedulerArea.Worker.Contract
{
    /// <summary>
    /// Class <c>ContractModel</c> is a page model class that contains data and methods 
    /// needed to manage and render contract index page. 
    /// </summary>
    /// <param name="workerRepository">Worker repository passed as injected depedency. </param>
    public class ContractModel(IWorkerRepository workerRepository) : PageModel
    {
        /// <value>
        /// Worker repository.
        /// </value>
        private IWorkerRepository _repository { get; set; } = workerRepository;

        /// <value>
        /// DTO containing currenct contract data. 
        /// </value>
        public Domain.Contract? Contract { get; private set; }

        /// <value>
        /// Worker name. 
        /// </value>
        public string WorkerName { get; private set; } = "";

        /// <value>
        /// Worker surname.
        /// </value>
        public string WorkerSurname { get; private set; } = "";

        /// <value>
        /// Worker id.
        /// </value>
        [BindProperty]
        public Guid WorkerId { get; set; }

        /// <summary>
        /// The page GET function. 
        /// </summary>
        /// <returns>A rendered page if everything is ok. An error page otherwise. </returns>
        public IActionResult OnGet()
        {
            HttpContext.Request.RouteValues.TryGetValue("workerId", out object workerIdObject);

            WorkerId = new Guid(workerIdObject.ToString());

            var worker = _repository.GetWorker(WorkerId);

            if (worker == null)
            {
                return Error();
            }

            WorkerName = worker.Name;
            WorkerSurname = worker.Surname;
            Contract = worker.Contract;

            if (Contract == null)
            {
                return Error();
            }

            return Page();
        }

        /// <summary>
        /// The page error function. 
        /// </summary>
        /// <returns></returns>
        private IActionResult Error()
        {
            return RedirectToPage("./../../Error");
        }
    }
}
