using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Warehouse.Infrastructure.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public ICollection<Request> Requests { get; set; } = new List<Request>();

        public static implicit operator List<object>(Employee v)
        {
            throw new NotImplementedException();
        }
    }

    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
