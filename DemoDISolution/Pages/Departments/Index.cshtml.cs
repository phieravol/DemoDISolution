using DemoDISolution.Models;
using DemoDISolution.Services.Departments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoDISolution.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly IDepartmentService departmentService;

        public IndexModel(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        public List<Department> Departments { get; set; }
        [BindProperty(SupportsGet = true)] public string? SearchTerm { get; set; } 
		public async Task<IActionResult> OnGetAsync()
        {
            Departments = await departmentService.GetDepartmentResult(SearchTerm);
            return Page();
        }
    }
}
