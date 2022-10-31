using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Warehouse.Application.Services;
using Warehouse.Application.Services.Abstractions;
using Warehouse.Infrastructure;

namespace Warehouse.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<WarehouseContext>(options =>
                options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultDatabase"])
            );

            builder.Services.AddTransient<IContractService, ContractService>();
            builder.Services.AddTransient<IContainerService, ContainerService>();
            builder.Services.AddTransient<IEmployeeService, EmployeeService>();
            builder.Services.AddTransient<IRequestService, RequestService>();

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}