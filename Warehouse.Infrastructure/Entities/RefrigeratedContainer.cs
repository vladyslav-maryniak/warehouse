namespace Warehouse.Infrastructure.Entities
{
    public class RefrigeratedContainer : Container
    {
        public int MinTemperature { get; set; }
        public int MaxTemperature { get; set; }
    }
}
