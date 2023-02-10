using AutoMapper;

using WineSales.Config;
using WineSales.Domain.Exceptions;
using WineSales.Domain.Models;
using WineSales.Domain.ModelsBL;
using WineSales.Domain.RepositoryInterfaces;


namespace WineSales.Domain.Interactors
{
    public interface IWineInteractor
    {
        WineBL GetByAllFields(WineBL wine);
        WineBL CreateWine(WineBL wine);
        WineBL DeleteWine(int id);
    }

    public class WineInteractor : IWineInteractor
    {
        private readonly IWineRepository _wineRepository;
        private readonly IMapper _mapper;

        public WineInteractor(IWineRepository wineRepository,
                              IMapper mapper)
        {
            _wineRepository = wineRepository;
            _mapper = mapper;
        }

        public WineBL CreateWine(WineBL wine)
        {
            if (!IsWineCorrect(wine))
                throw new WineException("Invalid input of wine.");

            var existingWine = GetByAllFields(wine);

            if (existingWine != null)
                return _mapper.Map<WineBL>(_wineRepository.IncreaseNumber(existingWine.ID));

            wine.Number = WineConfig.MinNumber;
            var transmittedWine = _mapper.Map<Wine>(wine);
            return _mapper.Map<WineBL>(_wineRepository.Create(transmittedWine));
        }

        public WineBL GetByAllFields(WineBL wine)
        {
            var transmittedWine = _mapper.Map<Wine>(wine);
            return _mapper.Map<WineBL>(_wineRepository.GetByAllFields(transmittedWine));
        }

        public WineBL DeleteWine(int id)
        {
            var existingWine = _wineRepository.GetByID(id);

            if (existingWine == null)
                return null;

            if (existingWine.Number > WineConfig.MinNumber)
                return _mapper.Map<WineBL>(_wineRepository.DecreaseNumber(id));

            return _mapper.Map<WineBL>(_wineRepository.Delete(id));
        }

        private bool IsExistById(int id)
        {
            return _wineRepository.GetByID(id) != null;
        }

        private bool IsWineCorrect(WineBL wine)
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
