using WineSales.Domain.Models;
using WineSales.Domain.RepositoryInterfaces;
using WineSales.Domain.Exceptions;


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
        private readonly ISupplierRepository supplierRepository;

        public SupplierInteractor(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        public void CreateSupplier(Supplier supplier)
        {
            if (Exist(supplier.Name))
                throw new SupplierException("This supplier already exists.");

            supplier.License = false;
            supplierRepository.Create(supplier);
        }

        public List<Supplier> GetAll()
        {
            return supplierRepository.GetAll();
        }

        public Supplier GetByID(int id)
        {
            return supplierRepository.GetByID(id);
        }

        public Supplier GetByName(string name)
        {
            return supplierRepository.GetByName(name);
        }

        public Supplier GetBySupplierWineID(int supplierWineID)
        {
            return supplierRepository.GetBySupplierWineID(supplierWineID);
        }

        public void UpdateSupplier(Supplier supplier)
        {
            if (NotExist(supplier.ID))
                throw new SupplierException("This supplier doesn't exist.");

            supplierRepository.Update(supplier);
        }

        public void DeleteSupplier(Supplier supplier)
        {
            if (NotExist(supplier.ID))
                throw new SupplierException("This supplier doesn't exist.");

            supplierRepository.Delete(supplier);
        }

        private bool Exist(string name)
        {
            return supplierRepository.GetByName(name) != null;
        }

        private bool NotExist(int id)
        {
            return supplierRepository.GetByID(id) == null;
        }
    }
}
