namespace WineSales.Domain.Exceptions
{
    public class UserException : Exception
    {
        public UserException() : base() { }

        public UserException(string message) : base("User: " + message) { }

         public UserException(string message, Exception inner) : base(message, inner) { }
    }
}
