namespace Warehouse.API.DTOs.Requests
{
    public class AddRequestCommand
    {
        public DateTime TargetDate { get; set; }
        public int? EmployeeId { get; set; }
        public int ContractId { get; set; }
    }
}
