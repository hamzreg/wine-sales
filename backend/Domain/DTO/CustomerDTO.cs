namespace WineSales.Domain.DTO
{
    public class CustomerBaseDTO
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Phone { get; set; }
    }

    public class CustomerDTO: CustomerBaseDTO
    {
        public int ID { get; set; }
    }
}
