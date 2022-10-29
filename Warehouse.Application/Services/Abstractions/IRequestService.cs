using Warehouse.Infrastructure.Entities;

namespace Warehouse.Application.Services
{
    public interface IRequestService
    {
        Task<Request> AddAsync(Request request);
        Task DeleteAsync(int id);
        Task<Request[]> GetAllAsync();
        Task<Request> GetAsync(int id);
        Task UpdateAsync(Request request);
    }
}