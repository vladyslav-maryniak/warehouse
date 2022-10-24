using Microsoft.EntityFrameworkCore;
using Warehouse.Application.Services.Abstractions;
using Warehouse.Infrastructure;
using Warehouse.Infrastructure.Entities;

namespace Warehouse.Application.Services
{

    public class EmployeeService : IEmployeeService
    {
        private readonly WarehouseContext context;

        public EmployeeService(WarehouseContext context)
        {
            this.context = context;
        }

        public Task<Contract[]> GetAllAsync()
          => context.Employees
              .AsNoTracking()
              .ToArrayAsync();

        public Task<Contract?> GetAsync(int id)
            => context.Employees
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Employee> AddAsync(Employee employee)
        {
            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();

            return employee;
        }

        public async Task DeleteAsync(int id)
        {
            context.Employees.Remove(new Employee { Id = id });
            await context.SaveChangesAsync();
        }

    }
}
