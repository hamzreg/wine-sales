using WineSales.Domain.Models;
using WineSales.Domain.RepositoryInterfaces;
using WineSales.Domain.Exceptions;


namespace WineSales.Domain.Interactors
{
    public interface ICustomerInteractor
    {
        void CreateCustomer(Customer customer);
        Customer GetByID(int id);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
    }

    public class CustomerInteractor : ICustomerInteractor
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerInteractor(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Customer GetByID(int id)
        {
            return customerRepository.GetByID(id);
        }

        public void CreateCustomer(Customer customer)
        {
            if (Exist(customer.Phone))
                throw new CustomerException("This customer already exists.");

            customerRepository.Create(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            if (NotExist(customer.ID))
                throw new CustomerException("This customer doesn't exist.");

            customerRepository.Update(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            if (NotExist(customer.ID))
                throw new CustomerException("This customer doesn't exist.");

            customerRepository.Delete(customer);
        }

        private bool Exist(string phone)
        {
            return customerRepository.GetByPhone(phone) != null;
        }

        private bool NotExist(int id)
        {
            return customerRepository.GetByID(id) == null;
        }
    }
}
