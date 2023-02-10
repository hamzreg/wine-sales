using WineSales.Domain.Models;
using WineSales.Domain.RepositoryInterfaces;
using WineSales.Domain.Exceptions;

namespace WineSales.Data.Repositories
{
    public class SupplierWineRepository : ISupplierWineRepository
    {
        private readonly DataBaseContext _context;

        public SupplierWineRepository(DataBaseContext context)
        {
            _context = context;
        }

        public SupplierWine Create(SupplierWine supplierWine)
        {
            try
            {
                _context.SupplierWines.Add(supplierWine);
                _context.SaveChanges();

                return GetByID(supplierWine.ID);
            }
            catch
            {
                throw new SupplierWineException("Failed to create supplierWine.");
            }
        }

        public List<SupplierWine> GetAll()
        {
            return _context.SupplierWines.ToList();
        }

        public SupplierWine GetByID(int id)
        {
            return _context.SupplierWines.Find(id);
        }

        public List<SupplierWine> GetByWineID(int wineID)
        {
            return _context.SupplierWines.Where(supplierWine => supplierWine.WineID == wineID)
                .ToList();
        }

        public List<SupplierWine> GetByPrice(double price)
        {
            return _context.SupplierWines.Where(supplierWine => supplierWine.Price == price)
                .ToList();
        }

        public List<SupplierWine> GetByPercent(int percent)
        {
            return _context.SupplierWines.Where(supplierWine => supplierWine.Percent == percent)
                .ToList();
        }

        public (List<Wine>, List<SupplierWine>) GetBySupplierID(int supplierID)
        {
            var supplierWines = _context.SupplierWines
                .Where(supplierWine => supplierWine.SupplierID == supplierID)
                .ToList();

            var wines = new List<Wine>();
            foreach (SupplierWine supplierWine in supplierWines)
            {
                wines.Add(_context.Wines.Find(supplierWine.WineID));
            }

            return (wines, supplierWines);
        }

        public (List<int>, List<Wine>, List<double>) GetAllWine()
        {
            var supplierWines = GetAll();

            var ids = new List<int>();
            var wines = new List<Wine>();
            var prices = new List<double>();

            foreach (SupplierWine supplierWine in supplierWines)
            {
                ids.Add(supplierWine.ID);
                wines.Add(_context.Wines.Find(supplierWine.WineID));
                prices.Add(supplierWine.Price * (1 + supplierWine.Percent / 100.0));
            }

            return (ids, wines, prices);
        }

        public SupplierWine Update(SupplierWine supplierWine)
        {
            try
            {
                _context.SupplierWines.Update(supplierWine);
                _context.SaveChanges();

                return GetByID(supplierWine.ID);
            }
            catch
            {
                throw new SupplierWineException("Failed to update supplierWine.");
            }
        }

        public SupplierWine Delete(int id)
        {
            try
            {
                var foundSupplierWine = GetByID(id);

                if (foundSupplierWine == null)
                    return null;
                else
                {
                    _context.SupplierWines.Remove(foundSupplierWine);
                    _context.SaveChanges();

                    return foundSupplierWine;
                }
            }
            catch
            {
                throw new SupplierWineException("Failed to delete supplierWine.");
            }
        }
    }
}
