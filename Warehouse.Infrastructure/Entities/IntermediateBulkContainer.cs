namespace Warehouse.Infrastructure.Entities
{
    public class IntermediateBulkContainer : Container
    {
        public bool IsFlexible { get; set; }
        public bool IsRigid { get; set; }
        public bool IsVentilated { get; set; }
    }
}
