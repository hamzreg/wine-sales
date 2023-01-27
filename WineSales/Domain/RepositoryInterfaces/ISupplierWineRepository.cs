using WineSales.Domain.Models;


namespace WineSales.Domain.RepositoryInterfaces
{
    public interface ISupplierWineRepository : ICrudRepository<SupplierWine>
    {
        List<SupplierWine> GetByWineID(int wineID);
        List<SupplierWine> GetByPrice(double price);
        List<SupplierWine> GetByPercent(int percent);
        (List<Wine>, List<SupplierWine>) GetBySupplierID(int supplierID);
        (List<int>, List<Wine>, List<double>) GetAllWine();
        (List<Wine>, List<string>, List<double>) GetByAdmin();
        (List<Wine>, List<double>) GetRating();
    }
}
