using DemoDISolution.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoDISolution.Services.Departments
{
    public class DepartmentService: IDepartmentService
    {
        private readonly DemoDIContext context;

        public DepartmentService(DemoDIContext context)
        {
            this.context = context;
        }

        public async Task CreateDepartmentAsync(Department department)
        {
            context.Departments.Add(department);
            await context.SaveChangesAsync();
        }

        public async Task<List<Department>> GetDepartmentResult(string? searchTerm)
        {
            var query = from d in context.Departments
                        select d;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(x => x.DepartmentName.Contains(searchTerm) || x.Address.Contains(searchTerm));
            }

            var result = await query.ToListAsync();
            return result;
        }
    }
}
