using WineSales.Domain.Exceptions;
using WineSales.Domain.Models;
using WineSales.Domain.RepositoryInterfaces;


namespace WineSales.Data.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly DataBaseContext _context;

        public SupplierRepository(DataBaseContext context)
        {
            _context = context;
        }

        public void Create(Supplier supplier)
        {
            try
            {
                _context.Suppliers.Add(supplier);
                _context.SaveChanges();
            }
            catch
            {
                throw new SupplierException("Failed to create supplier.");
            }
        }

        public List<Supplier> GetAll()
        {
            return _context.Suppliers.ToList();
        }

        public Supplier GetByID(int id)
        {
            return _context.Suppliers.Find(id);
        }

        public Supplier GetByName(string name)
        {
            return _context.Suppliers.FirstOrDefault(supplier => supplier.Name == name);
        }

        public List<Supplier> GetByCountry(string country)
        {
            return _context.Suppliers.Where(supplier => supplier.Country == country)
                .ToList();
        }

        public List<Supplier> GetByLicense(bool license)
        {
            return _context.Suppliers.Where(supplier => supplier.License == license)
                .ToList();
        }

        public Supplier GetBySupplierWineID(int supplierWineID)
        {
            var supplierWine = _context.SupplierWines.Find(supplierWineID);
            return GetByID(supplierWine.SupplierID);
        }

        public void Update(Supplier supplier)
        {
            try
            {
                _context.Suppliers.Update(supplier);
                _context.SaveChanges();
            }
            catch
            {
                throw new SupplierException("Failed to update supplier.");
            }
        }

        public void Delete(Supplier supplier)
        {
            var foundSupplier = GetByID(supplier.ID);

            if (foundSupplier == null)
                throw new SupplierException("Failed to get supplier by id.");

            try
            {
                _context.Suppliers.Remove(foundSupplier);
                _context.SaveChanges();
            }
            catch
            {
                throw new SupplierException("Failed to delete supplier.");
            }
        }
    }
}
