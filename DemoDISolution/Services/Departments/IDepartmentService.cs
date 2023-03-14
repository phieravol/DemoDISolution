namespace DemoDISolution.Services.Departments
{
    public interface IDepartmentService
    {
        Task CreateDepartmentAsync(Models.Department department);
        Task<List<Models.Department>> GetDepartmentResult(string? searchTerm);
    }
}
