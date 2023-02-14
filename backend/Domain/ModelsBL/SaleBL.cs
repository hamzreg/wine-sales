namespace WineSales.Domain.ModelsBL
{
    public class SaleBL
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int SupplierWineID { get; set; }
        public double SellingPrice { get; set; }
        public double PurchasePrice { get; set; }
        public double Profit { get; set; }
        public DateOnly Date { get; set; }
        public int WineNumber { get; set; }
    }
}
