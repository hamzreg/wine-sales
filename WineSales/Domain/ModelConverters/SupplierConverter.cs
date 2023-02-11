using WineSales.Domain.DTO;
using WineSales.Domain.ModelsBL;
using WineSales.Domain.Interactors;


namespace WineSales.Domain.ModelCoverters
{
    public class SupplierConverter
    {
        private readonly ISupplierInteractor _supplierInteractor;

        public SupplierConverter(ISupplierInteractor supplierInteractor)
        {
            _supplierInteractor = supplierInteractor;
        }

        public SupplierBL ConvertSupplier(int id, SupplierBaseDTO supplier)
        {
            var existingSupplier = _supplierInteractor.GetByID(id);

            return new SupplierBL
            {
                ID = id,
                Name = supplier.Name ?? existingSupplier.Name,
                Country = supplier.Country ?? existingSupplier.Country,
                License = supplier.License ?? existingSupplier.License
            };
        }
    }
}
