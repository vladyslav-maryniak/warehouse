using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Warehouse.Infrastructure.Entities;

namespace Warehouse.Infrastructure
{
    public class WarehouseContext : DbContext
    {
        public WarehouseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contract> Contracts => Set<Contract>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Request> Requests => Set<Request>();
        public DbSet<Container> Containers => Set<Container>();
        public DbSet<FreightContainer> FreightContainers => Set<FreightContainer>();
        public DbSet<IntermediateBulkContainer> IntermediateBulkContainers => Set<IntermediateBulkContainer>();
        public DbSet<RefrigeratedContainer> RefrigeratedContainers => Set<RefrigeratedContainer>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
