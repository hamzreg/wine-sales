using WineSales.Domain.Models;


namespace WineSales.Domain.RepositoryInterfaces
{
    public interface ISupplierRepository : ICrudRepository<Supplier>
    {
        Supplier GetByName(string name);
        List<Supplier> GetByCountry(string country);
        List<Supplier> GetByLicense(bool license);
        Supplier GetBySupplierWineID(int supplierWineID);
    }
}
