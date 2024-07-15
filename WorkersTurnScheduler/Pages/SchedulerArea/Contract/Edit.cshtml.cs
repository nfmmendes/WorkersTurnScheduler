using System.Runtime;
using WorkersTurnScheduler.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkersTurnScheduler.Services;
using Microsoft.EntityFrameworkCore;

namespace WorkersTurnScheduler.Pages.SchedulerArea.Contract
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
        
        public Guid ContractId { get; set; }

        /// <value>
        /// DTO holding the current/new contract data.
        /// </value>
        [BindProperty]
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

            if(contractIdObject != null)
                ContractId = new Guid(contractIdObject.ToString());

            EditContract = _contractRepository.getContract(ContractId);

            if (EditContract == null) {
                return RedirectToPage($"../Contract/Index");
            }

            return Page();
        }

        /// <summary>
        /// Edit page post method
        /// </summary>
        /// <param name="id"> Id of the contract to be edited</param>
        /// <returns> A page, according to the edition result </returns>
        public IActionResult OnPost(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            if (EditContract != null) {
                _contractRepository.updateContract(id, EditContract);
                return Redirect($"../Index");
            }

            return Page();
        }
    }
}
