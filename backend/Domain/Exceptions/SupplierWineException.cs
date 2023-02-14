namespace WineSales.Domain.Exceptions
{
    public class SupplierWineException : Exception
    {
        public SupplierWineException() : base() { }

        public SupplierWineException(string message) : base("SupplierWine: " + message) { }

        public SupplierWineException(string message, Exception inner) : base(message, inner) { }
    }
}
