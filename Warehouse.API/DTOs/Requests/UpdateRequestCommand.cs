namespace Warehouse.API.DTOs.Requests
{
    public class UpdateRequestCommand
    {
        public int Id { get; set; }
        public DateTime TargetDate { get; set; }
        public int? EmployeeId { get; set; }
        public int ContractId { get; set; }
    }
}
