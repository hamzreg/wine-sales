namespace WineSales.Domain.Exceptions
{
    public class SupplierException : Exception
    {
        public SupplierException() : base() { }

        public SupplierException(string message) : base("Supplier: " + message) { }

        public SupplierException(string message, Exception inner) : base(message, inner) { }
    }
}
