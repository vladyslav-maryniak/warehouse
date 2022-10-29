using Microsoft.AspNetCore.Mvc;
using Warehouse.Application.Services.Abstractions;
using Warehouse.Infrastructure.Entities;

namespace Warehouse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainersController : ControllerBase
    {
        private readonly IContainerService containerService;

        public ContainersController(IContainerService containerService)
        {
            this.containerService = containerService;
        }

        [HttpGet]
        public async Task<ActionResult<Contract[]>> GetAllAsync()
        {
            var result = await containerService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Contract?>> GetAsync(int id)
        {
            var result = await containerService.GetAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Contract>> AddAsync(Container container)
        {
            var result = await containerService.AddAsync(container);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(Container container)
        {
            await containerService.UpdateAsync(container);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await containerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
