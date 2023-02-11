using WineSales.Domain.DTO;
using WineSales.Domain.ModelsBL;
using WineSales.Domain.Interactors;


namespace WineSales.Domain.ModelCoverters
{
    public class CustomerConverter
    {
        private readonly ICustomerInteractor _customerInteractor;

        public CustomerConverter(ICustomerInteractor customerInteractor)
        {
            _customerInteractor = customerInteractor;
        }

        public CustomerBL ConvertCustomer(int id, CustomerBaseDTO customer)
        {
            var existingCustomer = _customerInteractor.GetByID(id);

            return new CustomerBL
            {
                ID = id,
                Name = customer.Name ?? existingCustomer.Name,
                Surname = customer.Surname ?? existingCustomer.Surname,
                Phone = customer.Phone ?? existingCustomer.Phone
            };
        }
    }
}
