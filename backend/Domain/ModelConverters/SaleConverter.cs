using WineSales.Domain.DTO;
using WineSales.Domain.ModelsBL;
using WineSales.Domain.Interactors;


namespace WineSales.Domain.ModelConverters
{
    public class SaleConverter
    {
        private readonly ISaleInteractor _saleInteractor;

        public SaleConverter(ISaleInteractor saleInteractor)
        {
            _saleInteractor = saleInteractor;
        }

        public SaleBL ConvertSale(int id, SaleBaseDTO sale)
        {
            var existingSale = _saleInteractor.GetByID(id);

            return new SaleBL
            {
                ID = id,
                CustomerID = sale.CustomerID ?? existingSale.CustomerID,
                SupplierWineID = sale.SupplierWineID ?? existingSale.SupplierWineID,
                SellingPrice = sale.SellingPrice ?? existingSale.SellingPrice,
                PurchasePrice = sale.PurchasePrice ?? existingSale.PurchasePrice,
                Profit = sale.Profit ?? existingSale.Profit,
                Date = sale.Date ?? existingSale.Date,
                WineNumber = sale.WineNumber ?? existingSale.WineNumber
            };
        }
    }
}
