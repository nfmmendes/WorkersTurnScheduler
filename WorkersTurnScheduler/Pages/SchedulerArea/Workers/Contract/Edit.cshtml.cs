using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WorkersTurnScheduler.Pages.SchedulerArea.Workers.Contract
{
    public class EditModel : PageModel
    {
        public UInt128 ContractId { get; set; }

        public void OnGet()
        {
            Console.WriteLine(ContractId);
        }
    }
}
