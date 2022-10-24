using Microsoft.AspNetCore.Mvc;
using Warehouse.Application.Services.Abstractions;
using Warehouse.Infrastructure.Entities;

namespace Warehouse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestService requestService;

        public ContractsController(IRequestService requestService)
        {
            this.requestService = requestService;
        }

        [HttpGet]
        public async Task<ActionResult<Request[]>> GetAllAsync()
        {
            var result = await requestService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Request?>> GetAsync(int id)
        {
            var result = await requestService.GetAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Request>> AddAsync(Request request)
        {
            var result = await requestService.AddAsync(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(Request request)
        {
            await requestService.UpdateAsync(request);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await requestService.DeleteAsync(id);
            return NoContent();
        }


    }
}
