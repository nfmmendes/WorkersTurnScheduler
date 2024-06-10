using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkersTurnScheduler.Domain;
using WorkersTurnScheduler.Services;

namespace WorkersTurnScheduler.Pages.SchedulerArea.Workers.Contract
{
    public class EditModel : PageModel
    {
        IContractRepository _contractRepository;
        
        public UInt128 ContractId { get; set; }

        public Domain.Contract? EditContract { get; set; }

        public EditModel(IContractRepository contractRepository) { 
            _contractRepository = contractRepository;
        }

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
