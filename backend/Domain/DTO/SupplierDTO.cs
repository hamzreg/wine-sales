namespace WineSales.Domain.DTO
{
    public class SupplierBaseDTO
    {
        public string? Name { get; set; }
        public string? Country { get; set; }
        public bool? License { get; set; }
    }

    public class SupplierDTO: SupplierBaseDTO
    {
        public int ID { get; set; }
    }
}
