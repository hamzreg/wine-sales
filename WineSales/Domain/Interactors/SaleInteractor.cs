using WineSales.Config;
using WineSales.Domain.Exceptions;
using WineSales.Domain.Models;
using WineSales.Domain.RepositoryInterfaces;


namespace WineSales.Domain.Interactors
{
    public interface ISaleInteractor
    {
        void CreateSale(Sale sale);
        (List<Wine>, List<Sale>) GetBySupplierID(int supplierID);
        (List<Wine>, List<string>, List<Sale>) GetByAdmin();
    }

    public class SaleInteractor : ISaleInteractor
    {
        private readonly ISaleRepository _saleRepository;
        public SaleInteractor(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public void CreateSale(Sale sale)
        {
            if (sale.WineNumber < WineConfig.MinNumber)
                throw new SaleException("Invalid input of wine number.");

            _saleRepository.Create(sale);
        }

        public (List<Wine>, List<Sale>) GetBySupplierID(int supplierID)
        {
            return _saleRepository.GetBySupplierID(supplierID);
        }

        public (List<Wine>, List<string>, List<Sale>) GetByAdmin()
        {
            return _saleRepository.GetByAdmin();
        }
    }
}
