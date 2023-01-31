using WineSales.Domain.Exceptions;
using WineSales.Domain.Models;
using WineSales.Domain.RepositoryInterfaces;


namespace WineSales.Domain.Interactors
{
    public interface ISupplierInteractor
    {
        void CreateSupplier(Supplier supplier);
        List<Supplier> GetAll();
        Supplier GetByID(int id);
        Supplier GetByName(string name);
        Supplier GetBySupplierWineID(int supplierWineID);
        void UpdateSupplier(Supplier supplier);
        void DeleteSupplier(Supplier supplier);
    }

    public class SupplierInteractor : ISupplierInteractor
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierInteractor(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public void CreateSupplier(Supplier supplier)
        {
            if (IsExistByName(supplier.Name))
                throw new SupplierException("This supplier already exists.");

            supplier.License = false;
            _supplierRepository.Create(supplier);
        }

        public List<Supplier> GetAll()
        {
            return _supplierRepository.GetAll();
        }

        public Supplier GetByID(int id)
        {
            return _supplierRepository.GetByID(id);
        }

        public Supplier GetByName(string name)
        {
            return _supplierRepository.GetByName(name);
        }

        public Supplier GetBySupplierWineID(int supplierWineID)
        {
            return _supplierRepository.GetBySupplierWineID(supplierWineID);
        }

        public void UpdateSupplier(Supplier supplier)
        {
            if (!IsExistById(supplier.ID))
                throw new SupplierException("This supplier doesn't exist.");

            if (IsNameTaken(supplier.ID, supplier.Name))
                throw new SupplierException("This name is already taken.");

            _supplierRepository.Update(supplier);
        }

        public void DeleteSupplier(Supplier supplier)
        {
            if (!IsExistById(supplier.ID))
                throw new SupplierException("This supplier doesn't exist.");

            _supplierRepository.Delete(supplier);
        }

        private bool IsExistByName(string name)
        {
            return _supplierRepository.GetByName(name) != null;
        }

        private bool IsExistById(int id)
        {
            return _supplierRepository.GetByID(id) != null;
        }

        private bool IsNameTaken(int id, string name)
        {
            return _supplierRepository.GetAll().Any(obj =>
                                                    obj.ID != id &&
                                                    obj.Name == name);
        }
    }
}
