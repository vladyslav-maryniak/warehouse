using Warehouse.Infrastructure.Entities;

namespace Warehouse.Application.Services.Abstractions
{
    public interface IContractService
    {
        Task<Contract[]> GetAllAsync();
        Task<Contract?> GetAsync(int id);
        Task<Contract> AddAsync(Contract contract);
        Task UpdateAsync(Contract contract);
        Task DeleteAsync(int id);
    }
}