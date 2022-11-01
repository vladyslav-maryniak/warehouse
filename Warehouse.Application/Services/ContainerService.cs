using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Warehouse.Application.Services.Abstractions;
using Warehouse.Infrastructure;
using Warehouse.Infrastructure.Entities;

namespace Warehouse.Application.Services
{
    public class ContainerService : IContainerService
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

        public Task<Container[]> GetAllBycontractIdAsync(int contractId)
            => context.Containers
                .Where(x => x.ContractId == contractId)
                .ToArrayAsync();

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
