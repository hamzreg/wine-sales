namespace WineSales.Domain.Exceptions
{
    public class WineException : Exception
    {
        public WineException() : base() { }

        public WineException(string message) : base("Wine: " + message) { }

        public WineException(string message, Exception inner) : base(message, inner) { }
    }
}
