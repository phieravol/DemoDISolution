using DemoDISolution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoDISolution.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly DemoDIContext context;

		public IndexModel(DemoDIContext context)
		{
			this.context = context;
		}

        public List<Department> Departments { get; set; }
		public async Task<IActionResult> OnGetAsync()
        {
            Departments = context.Departments.ToList();
            return Page();
        }
    }
}
