using WineSales.Config;
using WineSales.Domain.Exceptions;
using WineSales.Domain.Models;
using WineSales.Domain.RepositoryInterfaces;


namespace WineSales.Domain.Interactors
{
    public interface IWineInteractor
    {
        Wine GetByAllFields(Wine wine);
        void CreateWine(Wine wine);
        void DeleteWine(Wine wine);
    }

    public class WineInteractor : IWineInteractor
    {
        private readonly IWineRepository _wineRepository;

        public WineInteractor(IWineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }

        public void CreateWine(Wine wine)
        {
            if (!IsWineCorrect(wine))
                throw new WineException("Invalid input of wine.");

            var existingWine = GetByAllFields(wine);

            if (existingWine != null)
            {
                _wineRepository.IncreaseNumber(existingWine.ID);
                return;
            }

            wine.Number = WineConfig.MinNumber;
            _wineRepository.Create(wine);
        }

        public Wine GetByAllFields(Wine wine)
        {
            return _wineRepository.GetByAllFields(wine);
        }

        public void DeleteWine(Wine wine)
        {
            if (!IsExistById(wine.ID))
                throw new WineException("This wine doesn't exist.");

            if (wine.Number > WineConfig.MinNumber)
            {
                _wineRepository.DecreaseNumber(wine.ID);
                return;
            }

            _wineRepository.Delete(wine);
        }

        private bool IsExistById(int id)
        {
            return _wineRepository.GetByID(id) != null;
        }

        private bool IsWineCorrect(Wine wine)
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
