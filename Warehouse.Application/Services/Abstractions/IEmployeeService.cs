namespace Warehouse.Application.Services
{
    public interface IEmployeeService
    {
        Task<Employee> AddAsync(Employee employee);
        Task DeleteAsync(global::System.Int32 id);
        Task<Contract[]> GetAllAsync();
        Task<Contract> GetAsync(global::System.Int32 id);
    }
}