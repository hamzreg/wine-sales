using WineSales.Domain.Models;

namespace WineSales.Domain.RepositoryInterfaces
{
    public interface IWineRepository : ICrudRepository<Wine>
    {
        List<Wine> GetByKind(string kind);
        List<Wine> GetByColor(string color);
        List<Wine> GetBySugar(string sugar);
        List<Wine> GetByVolume(double volume);
        List<Wine> GetByAlcohol(double alcohol);
        List<Wine> GetByNumber(int number);
        Wine GetByAllFields(Wine wine);
        void IncreaseNumber(int id);
        void DecreaseNumber(int id);
    }
}
