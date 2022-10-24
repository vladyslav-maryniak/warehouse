using Microsoft.EntityFrameworkCore;
using Warehouse.Application.Services.Abstractions;
using Warehouse.Infrastructure;
using Warehouse.Infrastructure.Entities;

namespace Warehouse.Application.Services
{
    class RequestService : IRequestService
    {
        private readonly WarehouseContext context;

        public RequestService(WarehouseContext context)
        {
            this.context = context;
        }

        public Task<Request[]> GetAllAsync()
            => context.Requests
                .AsNoTracking()
                .ToArrayAsync();

        public Task<Request?> GetAsync(int id)
            => context.Requests
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Request> AddAsync(Request request)
        {
            await context.Requests.AddAsync(request);
            await context.SaveChangesAsync();

            return request;
        }

        public async Task UpdateAsync(Request request)
        {
            context.Requests.Update(request);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            context.Requests.Remove(new Request { Id = id });
            await context.SaveChangesAsync();
        }
    }
}
