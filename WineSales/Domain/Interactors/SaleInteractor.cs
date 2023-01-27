using WineSales.Domain.Models;
using WineSales.Domain.RepositoryInterfaces;
using WineSales.Domain.Exceptions;
using WineSales.Config;


namespace WineSales.Domain.Interactors
{
    public interface ISaleInteractor
    {
        void CreateSale(Sale sale, int percent);
        (List<Wine>, List<DateOnly>, List<double>) GetBySupplierID(int supplierID);
        (List<Wine>, List<string>, List<Sale>) GetByAdmin();
        void DeleteSale(Sale sale);
    }

    public class SaleInteractor : ISaleInteractor
    {
        private readonly ISaleRepository saleRepository;
        public SaleInteractor(ISaleRepository saleRepository)
        {
            this.saleRepository = saleRepository;
        }

        public void CreateSale(Sale sale, int percent)
        {
            if (percent < SaleConfig.MinPercent)
                throw new SaleException("Invalid input of percent.");
            else if (sale.PurchasePrice < SaleConfig.MinPurchasePrice)
                throw new SaleException("Invalid input of purchase price.");
            else if (sale.WineNumber < SaleConfig.MinWineNumer)
                throw new SaleException("Invalid input of wine number.");
            else if (Exist(sale))
                throw new SaleException("This sale already exists.");

            sale.SellingPrice = sale.PurchasePrice * (1 + percent / 100.0);

            saleRepository.Create(sale);
        }


        public (List<Wine>, List<DateOnly>, List<double>) GetBySupplierID(int supplierID)
        {
            return saleRepository.GetBySupplierID(supplierID);
        }

        public (List<Wine>, List<string>, List<Sale>) GetByAdmin()
        {
            return saleRepository.GetByAdmin();
        }

        public void DeleteSale(Sale sale)
        {
            if (!Exist(sale))
                throw new SaleException("This sale doesn't exist.");

            saleRepository.Delete(sale);
        }

        private bool Exist(Sale sale)
        {
            // TODO
            return true;
        }
    }
}
