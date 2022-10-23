namespace Warehouse.Infrastructure.Entities
{
    public class FreightContainer : Container
    {
        public bool IsHardTop { get; set; }
        public bool IsSoftTop { get; set; }
        public bool IsOpenTop { get; set; }
        public bool IsOpenSide { get; set; }
    }
}
