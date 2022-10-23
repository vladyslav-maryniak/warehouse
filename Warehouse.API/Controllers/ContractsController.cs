using Microsoft.AspNetCore.Mvc;
using Warehouse.Application.Services.Abstractions;
using Warehouse.Infrastructure.Entities;

namespace Warehouse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly IContractService contractService;

        public ContractsController(IContractService contractService)
        {
            this.contractService = contractService;
        }

        [HttpGet]
        public async Task<ActionResult<Contract[]>> GetAllAsync()
        {
            var result = await contractService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Contract?>> GetAsync(int id)
        {
            var result = await contractService.GetAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Contract>> AddAsync(Contract contract)
        {
            var result = await contractService.AddAsync(contract);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(Contract contract)
        {
            await contractService.UpdateAsync(contract);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await contractService.DeleteAsync(id);
            return NoContent();
        }
    }
}
