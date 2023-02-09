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
        SupplierWineBL GetByID(int id);
        (List<WineBL>, List<SupplierWineBL>) GetBySupplierID(int supplierID);
        (List<int>, List<WineBL>, List<double>) GetAllWine();
        SupplierWineBL UpdateSupplierWine(SupplierWineBL supplierWine);
        SupplierWineBL DeleteSupplierWine(SupplierWineBL supplierWine);
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

        public SupplierWineBL GetByID(int id)
        {
            return _mapper.Map<SupplierWineBL>(_supplierWineRepository.GetByID(id));
        }

        public (List<WineBL>, List<SupplierWineBL>) GetBySupplierID(int supplierID)
        {
            return _mapper.Map<(List<WineBL>, List<SupplierWineBL>)>(_supplierWineRepository.GetBySupplierID(supplierID));
        }

        public (List<int>, List<WineBL>, List<double>) GetAllWine()
        {
            return _mapper.Map<(List<int>, List<WineBL>, List<double>)>(_supplierWineRepository.GetAllWine());
        }

        public SupplierWineBL UpdateSupplierWine(SupplierWineBL supplierWine)
        {
            if (!IsSupplierWineCorrect(supplierWine))
                throw new SupplierWineException("Invalid input of supplierWine.");
            else if (!IsExistById(supplierWine.ID))
                throw new SupplierWineException("This supplier doesn't have this wine.");

            var transmittedSupplierWine = _mapper.Map<SupplierWine>(supplierWine);
            return _mapper.Map<SupplierWineBL>(_supplierWineRepository.Update(transmittedSupplierWine));
        }

        public SupplierWineBL DeleteSupplierWine(SupplierWineBL supplierWine)
        {
            if (!IsExistById(supplierWine.ID))
                throw new SupplierWineException("This supplier doesn't have this wine.");

            var transmittedSupplierWine = _mapper.Map<SupplierWine>(supplierWine);
            return _mapper.Map<SupplierWineBL>(_supplierWineRepository.Delete(transmittedSupplierWine));
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
    }
}
