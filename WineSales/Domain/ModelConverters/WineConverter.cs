using WineSales.Domain.DTO;
using WineSales.Domain.ModelsBL;
using WineSales.Domain.Interactors;


namespace WineSales.Domain.ModelCoverters
{
    public class WineConverter
    {
        private readonly IWineInteractor _wineInteractor;

        public WineConverter(IWineInteractor wineInteractor)
        {
            _wineInteractor = wineInteractor;
        }

        public WineBL ConvertWine(int id, WineBaseDTO wine)
        {
            var existingWine = _wineInteractor.GetByID(id);

            return new WineBL
            {
                ID = id,
                Kind = wine.Kind ?? existingWine.Kind,
                Color = wine.Color ?? existingWine.Color,
                Sugar = wine.Sugar ?? existingWine.Sugar,
                Volume = wine.Volume ?? existingWine.Volume,
                Alcohol = wine.Alcohol ?? existingWine.Alcohol,
                Number = wine.Number ?? existingWine.Number
            };
        }
    }
}