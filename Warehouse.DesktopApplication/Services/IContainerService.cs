using Refit;
using System.Threading.Tasks;
using Warehouse.Infrastructure.Entities;

namespace Warehouse.DesktopApplication.Services
{
    public interface IContainerService
    {
        [Get("/api/containers")]
        Task<Container[]> GetAllAsync();

        [Get("/api/containers/{containerId}")]
        Task<Container[]> GetAllBycontractIdAsync(int containerId);

        [Get("/api/containers/{id}")]
        Task<Container?> GetAsync(int id);

        [Post("/api/containers")]
        Task<Container> AddAsync(Container container);

        [Put("/api/containers")]
        Task UpdateAsync(Container container);

        [Delete("/api/containers/{id}")]
        Task DeleteAsync(int id);
    }
}