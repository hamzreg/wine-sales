namespace WineSales.Domain.ModelsBL
{
    public class SupplierWineBL
    {
        public int ID { get; set; }
        public int SupplierID { get; set; }
        public int WineID { get; set; }
        public double Price { get; set; }
        public int Percent { get; set; }
    }
}
