namespace WineSales.Domain.DTO
{
    public class WineBaseDTO
    {
        public string? Kind { get; set; }
        public string? Color { get; set; }
        public string? Sugar { get; set; }
        public double? Volume { get; set; }
        public double? Alcohol { get; set; }
        public int? Number { get; set; }
    }

    public class WineDTO: WineBaseDTO
    {
        public int ID { get; set; }
    }
}
