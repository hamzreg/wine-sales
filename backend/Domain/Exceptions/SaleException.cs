namespace WineSales.Domain.Exceptions
{
    public class SaleException : Exception
    {
        public SaleException() : base() { }

        public SaleException(string message) : base("Sale: " + message) { }

        public SaleException(string message, Exception inner) : base(message, inner) { }
    }
}
