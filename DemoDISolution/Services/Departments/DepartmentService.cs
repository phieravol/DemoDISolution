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

        public async Task DeleteDepartmentAsync(Department department)
        {
            context.Departments.Remove(department);
            await context.SaveChangesAsync();
        }

        public async Task EditDepartmentAsync(Department department)
        {
            context.Attach(department).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<Department> GetDepartmentByIdAsync(int? id)
        {
            return await context.Departments.FirstOrDefaultAsync(x => x.DepartmentId == id);
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
