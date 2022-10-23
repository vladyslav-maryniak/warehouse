using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Warehouse.Infrastructure.Entities
{
    public class Request
    {
        public int Id { get; set; }
        public DateTime TargetDate { get; set; }

        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public int ContractId { get; set; }
        public Contract Contract { get; set; } = null!;
    }

    public class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Employee)
                   .WithMany(x => x.Requests)
                   .HasForeignKey(x => x.EmployeeId);

            builder.HasOne(x => x.Contract)
                   .WithMany(x => x.Requests)
                   .HasForeignKey(x => x.ContractId);
        }
    }
}
