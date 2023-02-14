namespace WineSales.Domain.DTO
{
    public class SupplierWineBaseDTO
    {
        public int? SupplierID { get; set; }
        public int? WineID { get; set; }
        public double? Price { get; set; }
        public int? Percent { get; set; }
    }

    public class SupplierWineDTO: SupplierWineBaseDTO
    {
        public int ID { get; set; }
    }
}
