using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkersTurnScheduler.Domain;
using WorkersTurnScheduler.Services;

namespace WorkersTurnScheduler.Pages.SchedulerArea.Workers.Contract
{
    /// <summary>
    /// Class <c>EditModel</c> is a page model that contains the data functions needed to 
    /// manage and render the "edit contract" page. 
    /// </summary>
    public class EditModel : PageModel
    {
        /// <value>
        /// The contract repository.
        /// </value>
        IContractRepository _contractRepository;
        
        public UInt128 ContractId { get; set; }

        /// <value>
        /// DTO holding the current/new contract data.
        /// </value>
        public Domain.Contract? EditContract { get; set; }

        /// <summary>
        /// Constructor. 
        /// </summary>
        /// <param name="contractRepository">Contract repository injected. </param>
        public EditModel(IContractRepository contractRepository) { 
            _contractRepository = contractRepository;
        }

        /// <summary>
        /// Page get function. 
        /// </summary>
        /// <returns>The edit page, if everything works fine, the contract page, if the contract index is invalid.</returns>
        public IActionResult OnGet()
        {
            HttpContext.Request.RouteValues.TryGetValue("contractId", out object contractIdObject);
            HttpContext.Request.RouteValues.TryGetValue("workerId", out object workerIdObject);

            ContractId = System.Convert.ToUInt64(contractIdObject);

            Console.WriteLine(ContractId);
            EditContract = _contractRepository.getContract(ContractId);

            if (EditContract == null) {
                return RedirectToPage($"./Worker/{System.Convert.ToUInt64(workerIdObject)}/Category/Index");
            }

            return Page();
        }
    }
}
