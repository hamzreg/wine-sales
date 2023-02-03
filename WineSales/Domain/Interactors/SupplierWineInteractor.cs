using WineSales.Config;
using WineSales.Domain.Exceptions;
using WineSales.Domain.Models;
using WineSales.Domain.RepositoryInterfaces;


namespace WineSales.Domain.Interactors
{
    public interface ISupplierWineInteractor
    {
        void CreateSupplierWine(SupplierWine supplierWine);
        SupplierWine GetByID(int id);
        (List<Wine>, List<SupplierWine>) GetBySupplierID(int supplierID);
        (List<int>, List<Wine>, List<double>) GetAllWine();
        void UpdateSupplierWine(SupplierWine supplierWine);
        void DeleteSupplierWine(SupplierWine supplierWine);
    }
    public class SupplierWineInteractor : ISupplierWineInteractor
    {
        private ISupplierWineRepository _supplierWineRepository;

        public SupplierWineInteractor(ISupplierWineRepository supplierWineRepository)
        {
            _supplierWineRepository = supplierWineRepository;
        }

        public void CreateSupplierWine(SupplierWine supplierWine)
        {
            if (!IsSupplierWineCorrect(supplierWine))
                throw new SupplierWineException("Invalid input of supplierWine.");
            else if (IsSupplierWine(supplierWine.SupplierID, supplierWine.WineID))
                throw new SupplierWineException("This supplier already has this wine.");

            _supplierWineRepository.Create(supplierWine);
        }

        public SupplierWine GetByID(int id)
        {
            return _supplierWineRepository.GetByID(id);
        }

        public (List<Wine>, List<SupplierWine>) GetBySupplierID(int supplierID)
        {
            return _supplierWineRepository.GetBySupplierID(supplierID);
        }

        public (List<int>, List<Wine>, List<double>) GetAllWine()
        {
            return _supplierWineRepository.GetAllWine();
        }

        public void UpdateSupplierWine(SupplierWine supplierWine)
        {
            if (!IsSupplierWineCorrect(supplierWine))
                throw new SupplierWineException("Invalid input of supplierWine.");
            else if (!IsExistById(supplierWine.ID))
                throw new SupplierWineException("This supplier doesn't have this wine.");

            _supplierWineRepository.Update(supplierWine);
        }

        public void DeleteSupplierWine(SupplierWine supplierWine)
        {
            if (!IsExistById(supplierWine.ID))
                throw new SupplierWineException("This supplier doesn't have this wine.");

            _supplierWineRepository.Delete(supplierWine);
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

        private bool IsSupplierWineCorrect(SupplierWine supplierWine)
        {
            if (supplierWine.Percent < WineConfig.MinPercent)
                return false;
            else if (supplierWine.Price < WineConfig.MinPurchasePrice)
                return false;
            return true;
        }
    }
}
