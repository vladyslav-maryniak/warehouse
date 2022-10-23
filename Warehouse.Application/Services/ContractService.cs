using Microsoft.EntityFrameworkCore;
using Warehouse.Application.Services.Abstractions;
using Warehouse.Infrastructure;
using Warehouse.Infrastructure.Entities;

namespace Warehouse.Application.Services
{
    public class ContractService : IContractService
    {
        private readonly WarehouseContext context;

        public ContractService(WarehouseContext context)
        {
            this.context = context;
        }

        public Task<Contract[]> GetAllAsync()
            => context.Contracts
                .AsNoTracking()
                .ToArrayAsync();

        public Task<Contract?> GetAsync(int id)
            => context.Contracts
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Contract> AddAsync(Contract contract)
        {
            await context.Contracts.AddAsync(contract);
            await context.SaveChangesAsync();

            return contract;
        }

        public async Task UpdateAsync(Contract contract)
        {
            context.Contracts.Update(contract);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            context.Contracts.Remove(new Contract { Id = id });
            await context.SaveChangesAsync();
        }
    }
}
