namespace Warehouse.Application.Services
{
    public interface IRequestService
    {
        Task<Request> AddAsync(Request request);
        Task DeleteAsync(global::System.Int32 id);
        Task<Request[]> GetAllAsync();
        Task<Request> GetAsync(global::System.Int32 id);
        Task UpdateAsync(Request request);
    }
}