namespace WineSales.Domain.Models
{
    public class Supplier
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public bool License { get; set; }
    }
}
