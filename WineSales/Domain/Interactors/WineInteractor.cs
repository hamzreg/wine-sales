using WineSales.Domain.Models;
using WineSales.Domain.RepositoryInterfaces;
using WineSales.Domain.Exceptions;
using WineSales.Config;

namespace WineSales.Domain.Interactors
{
    public interface IWineInteractor
    {
        Wine GetByInfo(Wine wine);
        void CreateWine(Wine wine);
        void DeleteWine(Wine wine);
    }

    public class WineInteractor : IWineInteractor
    {
        private readonly IWineRepository wineRepository;

        public WineInteractor(IWineRepository wineRepository)
        {
            this.wineRepository = wineRepository;
        }

        public void CreateWine(Wine wine)
        {
            if (!CheckWine(wine))
                throw new WineException("Invalid input of wine.");
            else if (Exist(wine))
            {
                // TODO
            }

            wine.Number = WineConfig.MinNumber;
            wineRepository.Create(wine);
        }

        public Wine GetByInfo(Wine wine)
        {
            return wineRepository.GetByInfo(wine);
        }

        public void DeleteWine(Wine wine)
        {
            if (NotExist(wine.ID))
                throw new WineException("This wine doesn't exist.");
            else if (!CheckWine(wine))
                throw new WineException("Invalid input of wine.");
            else if (wine.Number > WineConfig.MinNumber)
            {
                var existingWine = wineRepository.GetByID(wine.ID);
                existingWine.Number--;
                return;
            }

            wineRepository.Delete(wine);
        }

        private bool Exist(Wine wine)
        {
            return wineRepository.GetAll().Any(obj =>
                                               obj.Kind == wine.Kind &&
                                               obj.Color == wine.Color &&
                                               obj.Sugar == wine.Sugar &&
                                               obj.Volume == wine.Volume &&
                                               obj.Alcohol == wine.Alcohol);
        }

        private bool NotExist(int id)
        {
            return wineRepository.GetByID(id) == null;
        }

        private bool CheckWine(Wine wine)
        {
            if (!WineConfig.Colors.Contains(wine.Color))
                return false;
            else if (!WineConfig.Sugar.Contains(wine.Sugar))
                return false;
            else if (wine.Volume < WineConfig.MinVolume ||
                     wine.Volume > WineConfig.MaxVolume)
                return false;
            else if (wine.Alcohol < WineConfig.MinAlcohol ||
                     wine.Alcohol > WineConfig.MaxAlcohol)
                return false;

            return true;
        }
    }
}
