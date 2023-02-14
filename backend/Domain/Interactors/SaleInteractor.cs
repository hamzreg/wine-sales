using AutoMapper;

using WineSales.Config;
using WineSales.Domain.Exceptions;
using WineSales.Domain.Models;
using WineSales.Domain.ModelsBL;
using WineSales.Domain.RepositoryInterfaces;


namespace WineSales.Domain.Interactors
{
    public interface ISaleInteractor
    {
        SaleBL CreateSale(SaleBL sale);
        List<SaleBL> GetAll();
        SaleBL GetByID(int id);
        List<SaleBL> GetBySupplierID(int supplierID);
        SaleBL UpdateSale(SaleBL sale);
        SaleBL DeleteSale(int id);
    }

    public class SaleInteractor : ISaleInteractor
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ISupplierWineRepository _supplierWineRepository;
        private readonly IMapper _mapper;

        public SaleInteractor(ISaleRepository saleRepository,
                              ISupplierWineRepository supplierWineRepository,
                              IMapper mapper)
        {
            _saleRepository = saleRepository;
            _supplierWineRepository = supplierWineRepository;
            _mapper = mapper;
        }

        public SaleBL CreateSale(SaleBL sale)
        {
            if (sale.WineNumber < WineConfig.MinNumber)
                throw new SaleException("Invalid input of wine number.");

            var transmittedSale = _mapper.Map<Sale>(sale);
            return _mapper.Map<SaleBL>(_saleRepository.Create(transmittedSale));
        }

        public List<SaleBL> GetAll()
        {
            return _mapper.Map<List<SaleBL>>(_saleRepository.GetAll());
        }

        public SaleBL GetByID(int id)
        {
            return _mapper.Map<SaleBL>(_saleRepository.GetByID(id));
        }

        public List<SaleBL> GetBySupplierID(int supplierID)
        {
            var supplierWines = _supplierWineRepository.GetBySupplierID(supplierID);

            var sales = new List<Sale>();

            foreach (SupplierWine supplierWine in supplierWines)
            {
                var nowSales = _saleRepository.GetBySupplierWineID(supplierWine.ID);

                if (nowSales.Count != 0)
                    sales.AddRange(nowSales);
            }

            return _mapper.Map<List<SaleBL>>(sales);
        }

        public SaleBL UpdateSale(SaleBL sale)
        {
            if (!IsExistById(sale.ID))
                return null;

            var transmittedSale = _mapper.Map<Sale>(sale);
            return _mapper.Map<SaleBL>(_saleRepository.Update(transmittedSale));
        }

        public SaleBL DeleteSale(int id)
        {
            if (!IsExistById(id))
                return null;

            return _mapper.Map<SaleBL>(_saleRepository.Delete(id));
        }

        private bool IsExistById(int id)
        {
            return _saleRepository.GetByID(id) != null;
        }

    }
}
