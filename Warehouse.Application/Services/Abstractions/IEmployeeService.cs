using Warehouse.Infrastructure.Entities;

namespace Warehouse.Application.Services
{
    public interface IEmployeeService
    {
        Task<Employee> AddAsync(Employee employee);
        Task DeleteAsync(global::System.Int32 id);
        Task<Employee[]> GetAllAsync();
        Task<Employee> GetAsync(global::System.Int32 id);
    }
}