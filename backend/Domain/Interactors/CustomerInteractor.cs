using AutoMapper;

using WineSales.Domain.Exceptions;
using WineSales.Domain.Models;
using WineSales.Domain.ModelsBL;
using WineSales.Domain.RepositoryInterfaces;


namespace WineSales.Domain.Interactors
{
    public interface ICustomerInteractor
    {
        CustomerBL CreateCustomer(CustomerBL customer);
        List<CustomerBL> GetAll();
        CustomerBL GetByID(int id);
        CustomerBL UpdateCustomer(CustomerBL customer);
        CustomerBL DeleteCustomer(int id);
    }

    public class CustomerInteractor : ICustomerInteractor
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerInteractor(ICustomerRepository customerRepository,
                                  IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public CustomerBL CreateCustomer(CustomerBL customer)
        {
            if (IsExistByPhone(customer.Phone))
                throw new CustomerException("This customer already exists.");

            var transmittedCustomer = _mapper.Map<Customer>(customer);
            return _mapper.Map<CustomerBL>(_customerRepository.Create(transmittedCustomer));
        }

        public List<CustomerBL> GetAll()
        {
            return _mapper.Map<List<CustomerBL>>(_customerRepository.GetAll());
        }

        public CustomerBL GetByID(int id)
        {
            return _mapper.Map<CustomerBL>(_customerRepository.GetByID(id));
        }

        public CustomerBL UpdateCustomer(CustomerBL customer)
        {
            if (!IsExistById(customer.ID))
                return null;

            if (IsPhoneTaken(customer.ID, customer.Phone))
                throw new CustomerException("This phone is already taken.");

            var transmittedCustomer = _mapper.Map<Customer>(customer);
            return _mapper.Map<CustomerBL>(_customerRepository.Update(transmittedCustomer));
        }

        public CustomerBL DeleteCustomer(int id)
        {
            if (!IsExistById(id))
                return null;

            return _mapper.Map<CustomerBL>(_customerRepository.Delete(id));
        }

        private bool IsExistById(int id)
        {
            return _customerRepository.GetByID(id) != null;
        }

        private bool IsExistByPhone(string phone)
        {
            return _customerRepository.GetByPhone(phone) != null;
        }

        private bool IsPhoneTaken(int id, string phone)
        {
            return _customerRepository.GetAll().Any(obj =>
                                                    obj.ID != id &&
                                                    obj.Phone == phone);
        }
    }
}
