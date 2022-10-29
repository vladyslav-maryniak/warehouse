using Refit;
using System.Threading.Tasks;
using Warehouse.Infrastructure.Entities;

namespace Warehouse.DesktopApplication.Services
{
    public interface IRequestService
    {
        [Get("/api/requests")]
        Task<Request[]> GetAllAsync();

        [Get("/api/requests/{id}")]
        Task<Request> GetAsync(int id);

        [Post("/api/requests")]
        Task<Request> AddAsync(Request request);

        [Put("/api/requests")]
        Task UpdateAsync(Request request);

        [Delete("/api/requests/{id}")]
        Task DeleteAsync(int id);
    }
}