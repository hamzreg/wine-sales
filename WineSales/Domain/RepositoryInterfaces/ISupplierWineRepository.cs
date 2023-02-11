using WineSales.Domain.Models;


namespace WineSales.Domain.RepositoryInterfaces
{
    public interface ISupplierWineRepository : ICrudRepository<SupplierWine>
    {
        List<SupplierWine> GetByWineID(int wineID);
        List<SupplierWine> GetByPrice(double price);
        List<SupplierWine> GetByPercent(int percent);
        List<SupplierWine> GetBySupplierID(int supplierID);
    }
}
