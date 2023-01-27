namespace WineSales.Domain.Exceptions
{
    public class CustomerException : Exception
    {
        public CustomerException() : base() { }

        public CustomerException(string message) : base("Customer: " + message) { }

        public CustomerException(string message, Exception inner) : base(message, inner) { }
    }
}
