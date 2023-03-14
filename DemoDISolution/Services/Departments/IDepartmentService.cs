using DemoDISolution.Models;

namespace DemoDISolution.Services.Departments
{
    public interface IDepartmentService
    {
        Task CreateDepartmentAsync(Models.Department department);
        Task DeleteDepartmentAsync(Department department);
        Task EditDepartmentAsync(Department department);
        Task<Department> GetDepartmentByIdAsync(int? id);
        Task<List<Models.Department>> GetDepartmentResult(string? searchTerm);
    }
}
