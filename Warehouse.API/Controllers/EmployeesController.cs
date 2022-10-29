using Microsoft.AspNetCore.Mvc;
using Warehouse.Application.Services;
using Warehouse.Application.Services.Abstractions;
using Warehouse.Infrastructure.Entities;

namespace Warehouse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<Employee[]>> GetAllAsync()
        {
            var result = await employeeService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddAsync(Employee employee)
        {
            var result = await employeeService.AddAsync(employee);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await employeeService.DeleteAsync(id);
            return NoContent();
        }

    }
}
