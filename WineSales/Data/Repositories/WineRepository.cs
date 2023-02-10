using WineSales.Domain.Exceptions;
using WineSales.Domain.Models;
using WineSales.Domain.RepositoryInterfaces;


namespace WineSales.Data.Repositories
{
    public class WineRepository : IWineRepository
    {
        private readonly DataBaseContext _context;

        public WineRepository(DataBaseContext context)
        {
            _context = context;
        }

        public Wine Create(Wine wine)
        {
            try
            {
                _context.Wines.Add(wine);
                _context.SaveChanges();

                return GetByID(wine.ID);
            }
            catch
            {
                throw new WineException("Failed to create wine.");
            }
        }

        public List<Wine> GetAll()
        {
            return _context.Wines.ToList();
        }

        public Wine GetByID(int id)
        {
            return _context.Wines.Find(id);
        }

        public Wine GetByAllFields(Wine wine)
        {
            return _context.Wines.FirstOrDefault(obj =>
                                                 obj.Kind == wine.Kind &&
                                                 obj.Color == wine.Color &&
                                                 obj.Sugar == wine.Sugar &&
                                                 obj.Volume == wine.Volume &&
                                                 obj.Alcohol == wine.Alcohol);
        }

        public List<Wine> GetByKind(string kind)
        {
            return _context.Wines.Where(wine => wine.Kind == kind)
                .ToList();
        }

        public List<Wine> GetByColor(string color)
        {
            return _context.Wines.Where(wine => wine.Color == color)
                .ToList();
        }

        public List<Wine> GetBySugar(string sugar)
        {
            return _context.Wines.Where(wine => wine.Sugar == sugar)
                .ToList();
        }

        public List<Wine> GetByVolume(double volume)
        {
            return _context.Wines.Where(wine => wine.Volume == volume)
                .ToList();
        }

        public List<Wine> GetByAlcohol(double alcohol)
        {
            return _context.Wines.Where(wine => wine.Alcohol == alcohol)
                .ToList();
        }

        public List<Wine> GetByNumber(int number)
        {
            return _context.Wines.Where(wine => wine.Number == number)
                .ToList();
        }

        public Wine Update(Wine wine)
        {
            try
            {
                _context.Wines.Update(wine);
                _context.SaveChanges();

                return GetByID(wine.ID);
            }
            catch
            {
                throw new WineException("Failed to update wine.");
            }
        }

        public Wine IncreaseNumber(int id)
        {
            try
            {
                var foundWine = GetByID(id);

                if (foundWine == null)
                    return null;
                else
                {
                    foundWine.Number++;
                    _context.Wines.Update(foundWine);
                    _context.SaveChanges();

                    return foundWine;
                }
            }
            catch
            {
                throw new WineException("Failed to increase number.");
            }
        }

        public Wine DecreaseNumber(int id)
        {
            try
            {
                var foundWine = GetByID(id);

                if (foundWine == null)
                    return null;
                else
                {
                    foundWine.Number--;
                    _context.Wines.Update(foundWine);
                    _context.SaveChanges();

                    return foundWine;
                }
            }
            catch
            {
                throw new WineException("Failed to decrease number.");
            }
        }

        public Wine Delete(int id)
        {
            try
            {
                var foundWine = GetByID(id);

                if (foundWine == null)
                    return null;
                else
                {
                    _context.Wines.Remove(foundWine);
                    _context.SaveChanges();

                    return foundWine;
                }
            }
            catch
            {
                throw new WineException("Failed to delete wine.");
            }
        }
    }
}
