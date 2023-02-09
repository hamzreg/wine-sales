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
        (List<WineBL>, List<SaleBL>) GetBySupplierID(int supplierID);
        (List<WineBL>, List<string>, List<SaleBL>) GetByAdmin();
    }

    public class SaleInteractor : ISaleInteractor
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public SaleInteractor(ISaleRepository saleRepository,
                              IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public SaleBL CreateSale(SaleBL sale)
        {
            if (sale.WineNumber < WineConfig.MinNumber)
                throw new SaleException("Invalid input of wine number.");

            var transmittedSale = _mapper.Map<Sale>(sale);
            return _mapper.Map<SaleBL>(_saleRepository.Create(transmittedSale));
        }

        public (List<WineBL>, List<SaleBL>) GetBySupplierID(int supplierID)
        {
            return _mapper.Map<(List<WineBL>, List<SaleBL>)>(_saleRepository.GetBySupplierID(supplierID));
        }

        public (List<WineBL>, List<string>, List<SaleBL>) GetByAdmin()
        {
            return _mapper.Map<(List<WineBL>, List<string>, List<SaleBL>)>(_saleRepository.GetByAdmin());
        }
    }
}
