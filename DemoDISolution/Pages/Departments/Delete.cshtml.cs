using DemoDISolution.Models;
using DemoDISolution.Services.Departments;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoDISolution.Pages.Departments
{
    public class DeleteModel : PageModel
    {
        private readonly IDepartmentService departmentService;

        public DeleteModel(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        [BindProperty(SupportsGet = true)] public int? id { get; set; }
        [BindProperty] public Department Department { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            if (id==null)
            {
                return NotFound();
            }

            Department = await departmentService.GetDepartmentByIdAsync(id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (id == null || Department == null)
            {
                return NotFound();
            }

            try
            {
                await departmentService.DeleteDepartmentAsync(Department);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return RedirectToPage("./Index");
        }
    }
}
