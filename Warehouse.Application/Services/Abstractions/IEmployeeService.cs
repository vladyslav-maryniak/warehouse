using Warehouse.Infrastructure.Entities;

namespace Warehouse.Application.Services
{
    public interface IEmployeeService
    {
        Task<Employee> AddAsync(Employee employee);
        Task DeleteAsync(int id);
        Task<Employee[]> GetAllAsync();
        Task<Employee> GetAsync(int id);
    }
}