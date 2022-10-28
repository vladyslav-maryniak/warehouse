using Warehouse.Infrastructure.Entities;

namespace Warehouse.Application.Services.Abstractions
{
    public interface IContainerService
    {
        Task<Container> AddAsync(Container container);
        Task DeleteAsync(int id);
        Task<Container[]> GetAllAsync();
        Task<Container?> GetAsync(int id);
        Task UpdateAsync(Container container);
    }
}