using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Warehouse.Infrastructure.Entities
{
    public class Container
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public ExternalDimensions ExternalDimensions { get; set; } = null!;
        public decimal InternalVolume { get; set; }

        public int? ContractId { get; set; }
        public Contract? Contract { get; set; }
    }

    public class ContainerConfiguration : IEntityTypeConfiguration<Container>
    {
        public void Configure(EntityTypeBuilder<Container> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .HasMaxLength(256);
            
            builder.Property(x => x.Price)
                   .HasPrecision(18, 8);
            
            builder.OwnsOne(x => x.ExternalDimensions);

            builder.Property(x => x.InternalVolume)
                   .HasPrecision(18, 8);

            builder.HasOne(x => x.Contract)
                   .WithMany(x => x.Containers)
                   .HasForeignKey(x => x.ContractId);
        }
    }
}
