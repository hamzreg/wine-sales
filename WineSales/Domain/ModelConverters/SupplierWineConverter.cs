using WineSales.Domain.DTO;
using WineSales.Domain.ModelsBL;
using WineSales.Domain.Interactors;


namespace WineSales.Domain.ModelConverters
{
    public class SupplierWineConverter
    {
        private readonly ISupplierWineInteractor _supplierWineInteractor;

        public SupplierWineConverter(ISupplierWineInteractor supplierWineInteractor)
        {
            _supplierWineInteractor = supplierWineInteractor;
        }

        public SupplierWineBL ConvertSupplierWine(int id, SupplierWineBaseDTO supplierWine)
        {
            var existingSupplierWine = _supplierWineInteractor.GetByID(id);

            return new SupplierWineBL
            {
                ID = id,
                SupplierID = supplierWine.SupplierID ?? existingSupplierWine.SupplierID,
                WineID = supplierWine.WineID ?? existingSupplierWine.WineID,
                Price = supplierWine.Price ?? existingSupplierWine.Price,
                Percent = supplierWine.Percent ?? existingSupplierWine.Percent
            };
        }
    }
}
