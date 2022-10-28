using Microsoft.EntityFrameworkCore;
using Warehouse.Application.Services.Abstractions;
using Warehouse.Infrastructure;
using Warehouse.Infrastructure.Entities;

namespace Warehouse.Application.Services
{
    internal class ContainerService : IContainerService
    {
        private readonly WarehouseContext context;

        public ContainerService(WarehouseContext context)
        {
            this.context = context;
        }

        public Task<Container[]> GetAllAsync()
            => context.Containers
                .AsNoTracking()
                .ToArrayAsync();

        public Task<Container?> GetAsync(int id)
            => context.Containers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Container> AddAsync(Container container)
        {
            await context.Containers.AddAsync(container);
            await context.SaveChangesAsync();

            return container;
        }

        public async Task UpdateAsync(Container container)
        {
            context.Containers.Update(container);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            context.Containers.Remove(new Container { Id = id });
            await context.SaveChangesAsync();
        }

    }
}
