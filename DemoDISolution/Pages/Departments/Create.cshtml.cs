using DemoDISolution.Models;
using DemoDISolution.Services.Departments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoDISolution.Pages.Departments
{
    public class CreateModel : PageModel
    {
        private readonly IDepartmentService departmentService;

        public CreateModel(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        [BindProperty] public Department Department { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            await departmentService.CreateDepartmentAsync(Department);
            return RedirectToPage("./Index");
        }
    }
}
