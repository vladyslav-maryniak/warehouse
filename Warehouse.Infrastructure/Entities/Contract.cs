using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Warehouse.Infrastructure.Entities
{
    public class Contract
    {
        public int Id { get; set; }
        public string Credential { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public ICollection<Request> Requests { get; set; } = new List<Request>();
        public ICollection<Container> Containers { get; set; } = new List<Container>();
    }

    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
