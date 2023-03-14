using DemoDISolution.Models;
using DemoDISolution.Services.Departments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DemoDISolution.Pages.Departments
{
    public class EditModel : PageModel
    {
        private readonly IDepartmentService departmentService;

        public EditModel(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        [BindProperty(SupportsGet = true)] public int? id { get; set; }
        [BindProperty] public Department Department { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (id == null)
            {
                return NotFound();
            }

            Department = await departmentService.GetDepartmentByIdAsync(id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (id == null || Department==null) { return NotFound(); }

            try
            {
                await departmentService.EditDepartmentAsync(Department);
            }
            catch (DbUpdateException ex)
            {
                return NotFound(ex.Message);
            }

            return RedirectToPage("./Index");
        }
    }
}
