using WineSales.Domain.Exceptions;
using WineSales.Domain.Models;
using WineSales.Domain.RepositoryInterfaces;


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
        private readonly ICustomerRepository _customerRepository;

        public CustomerInteractor(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        public void CreateCustomer(Customer customer)
        {
            if (IsExistByPhone(customer.Phone))
                throw new CustomerException("This customer already exists.");

            _customerRepository.Create(customer);
        }

        public Customer GetByID(int id)
        {
            return _customerRepository.GetByID(id);
        }

        public void UpdateCustomer(Customer customer)
        {
            if (!IsExistById(customer.ID))
                throw new CustomerException("This customer doesn't exist.");

            if (IsExistByPhone(customer.Phone))
                throw new CustomerException("This phone is already taken.");

            _customerRepository.Update(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            if (!IsExistById(customer.ID))
                throw new CustomerException("This customer doesn't exist.");

            _customerRepository.Delete(customer);
        }

        private bool IsExistByPhone(string phone)
        {
            return _customerRepository.GetByPhone(phone) != null;
        }

        private bool IsExistById(int id)
        {
            return _customerRepository.GetByID(id) != null;
        }
    }
}
