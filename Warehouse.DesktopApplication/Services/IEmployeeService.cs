using Refit;
using System.Threading.Tasks;
using Warehouse.Infrastructure.Entities;

namespace Warehouse.DesktopApplication.Services
{
    public interface IEmployeeService
    {
        [Get("/api/employees")]
        Task<Employee[]> GetAllAsync();

        [Get("/api/employees/{id}")]
        Task<Employee> GetAsync(int id);

        [Post("/api/employees")]
        Task<Employee> AddAsync(Employee employee);

        [Delete("/api/employees/{id}")]
        Task DeleteAsync(int id);
    }
}