using WineSales.Domain.Models;


namespace WineSales.Domain.RepositoryInterfaces
{
    public interface ICustomerRepository : ICrudRepository<Customer>
    {
        List<Customer> GetByName(string name);
        List<Customer> GetBySurname(string surname);
        Customer GetByPhone(string phone);
    }
}
