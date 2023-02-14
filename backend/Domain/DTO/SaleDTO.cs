namespace WineSales.Domain.DTO
{
    public class SaleBaseDTO
    {
        public int? CustomerID { get; set; }
        public int? SupplierWineID { get; set; }
        public double? SellingPrice { get; set; }
        public double? PurchasePrice { get; set; }
        public double? Profit { get; set; }
        public DateOnly? Date { get; set; }
        public int? WineNumber { get; set; }
    }

    public class SaleDTO: SaleBaseDTO
    {
        public int ID { get; set; }
    }
}
