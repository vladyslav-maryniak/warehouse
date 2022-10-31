using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.API.DTOs.Requests;
using Warehouse.Application.Services;
using Warehouse.Infrastructure.Entities;

namespace Warehouse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestService requestService;
        private readonly IMapper mapper;

        public RequestsController(IRequestService requestService, IMapper mapper)
        {
            this.requestService = requestService;
            this.mapper = mapper;
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
        public async Task<ActionResult<Request>> AddAsync(AddRequestCommand command)
        {
            var request = mapper.Map<Request>(command);
            var result = await requestService.AddAsync(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(UpdateRequestCommand command)
        {
            var request = mapper.Map<Request>(command);
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
