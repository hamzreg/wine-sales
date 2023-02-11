using AutoMapper;

using WineSales.Config;
using WineSales.Domain.Exceptions;
using WineSales.Domain.Models;
using WineSales.Domain.ModelsBL;
using WineSales.Domain.RepositoryInterfaces;


namespace WineSales.Domain.Interactors
{
    public interface ISupplierWineInteractor
    {
        SupplierWineBL CreateSupplierWine(SupplierWineBL supplierWine);
        List<SupplierWineBL> GetAll();
        SupplierWineBL GetByID(int id);
        List<SupplierWineBL> GetBySupplierID(int supplierID);
        SupplierWineBL UpdateSupplierWine(SupplierWineBL supplierWine);
        SupplierWineBL DeleteSupplierWine(int id);
    }

    public class SupplierWineInteractor : ISupplierWineInteractor
    {
        private ISupplierWineRepository _supplierWineRepository;
        private IMapper _mapper;

        public SupplierWineInteractor(ISupplierWineRepository supplierWineRepository,
                                      IMapper mapper)
        {
            _supplierWineRepository = supplierWineRepository;
            _mapper = mapper;
        }

        public SupplierWineBL CreateSupplierWine(SupplierWineBL supplierWine)
        {
            if (!IsSupplierWineCorrect(supplierWine))
                throw new SupplierWineException("Invalid input of supplierWine.");
            else if (IsSupplierWine(supplierWine.SupplierID, supplierWine.WineID))
                throw new SupplierWineException("This supplier already has this wine.");

            var transmittedSupplierWine = _mapper.Map<SupplierWine>(supplierWine);
            return _mapper.Map<SupplierWineBL>(_supplierWineRepository.Create(transmittedSupplierWine));
        }

        public List<SupplierWineBL> GetAll()
        {
            return _mapper.Map<List<SupplierWineBL>>(_supplierWineRepository.GetAll());
        }

        public SupplierWineBL GetByID(int id)
        {
            return _mapper.Map<SupplierWineBL>(_supplierWineRepository.GetByID(id));
        }

        public List<SupplierWineBL> GetBySupplierID(int supplierID)
        {
            return _mapper.Map<List<SupplierWineBL>>(_supplierWineRepository.GetBySupplierID(supplierID));
        }

        public SupplierWineBL UpdateSupplierWine(SupplierWineBL supplierWine)
        {
            if (!IsSupplierWineCorrect(supplierWine))
                throw new SupplierWineException("Invalid input of supplierWine.");
            else if (!IsExistById(supplierWine.ID))
                return null;

            var transmittedSupplierWine = _mapper.Map<SupplierWine>(supplierWine);
            return _mapper.Map<SupplierWineBL>(_supplierWineRepository.Update(transmittedSupplierWine));
        }

        public SupplierWineBL DeleteSupplierWine(int id)
        {
            if (!IsExistById(id))
                return null;

            return _mapper.Map<SupplierWineBL>(_supplierWineRepository.Delete(id));
        }

        private bool IsSupplierWine(int supplierID, int wineID)
        {
            return _supplierWineRepository.GetAll().Any(obj =>
                                                       obj.SupplierID == supplierID &&
                                                       obj.WineID == wineID);
        }

        private bool IsExistById(int id)
        {
            return _supplierWineRepository.GetByID(id) != null;
        }

        private bool IsSupplierWineCorrect(SupplierWineBL supplierWine)
        {
            if (supplierWine.Percent < WineConfig.MinPercent)
                return false;
            else if (supplierWine.Price < WineConfig.MinPurchasePrice)
                return false;
            return true;
        }

        private double GetSellingPrice(double purchasePrice, int percent)
        {
            return purchasePrice * (1 + percent / 100.0);
        }
    }
}
