using Refit;
using System.Threading.Tasks;
using Warehouse.Infrastructure.Entities;

namespace Warehouse.DesktopApplication.Services
{
    public interface IContractService
    {
        [Get("/api/contracts")]
        Task<Contract[]> GetAllAsync();

        [Get("/api/contracts/{id}")]
        Task<Contract?> GetAsync(int id);
        
        [Post("/api/contracts")]
        Task<Contract> AddAsync(Contract contract);

        [Put("/api/contracts")]
        Task UpdateAsync(Contract contract);

        [Delete("/api/contracts/{id}")]
        Task DeleteAsync(int id);
    }
}