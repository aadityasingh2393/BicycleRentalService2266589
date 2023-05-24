using BusinessLayer.Models;
using DataAccessLayer;
using DataAccessLayer.Repositories;

namespace BicycleRentalSystem.RentService.BusinessLayer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public CustomerDto GetCustomer(int customerId)
        {
            var customer = _customerRepository.GetCustomer(customerId);
            return ToCustomerDto(customer);
        }

        public IEnumerable<CustomerDto> GetAllCustomers()
        {
            var customers = _customerRepository.GetAllCustomers();
            return customers.Select(c => ToCustomerDto(c));
        }

        public void AddCustomer(CustomerDto customer)
        {
            var newCustomer = ToCustomer(customer);
            _customerRepository.AddCustomer(newCustomer);
            _customerRepository.Save();
        }

        public void UpdateCustomer(CustomerDto customer)
        {
            var existingCustomer = _customerRepository.GetCustomer(customer.CustomerId);
            if (existingCustomer != null)
            {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.Email = customer.Email;
                existingCustomer.Phone = customer.Phone;
                _customerRepository.UpdateCustomer(existingCustomer);
                _customerRepository.Save();
            }
        }
        public void DeleteCustomer(int customerId)
        {
            var customer = _customerRepository.GetCustomer(customerId);
            if (customer != null)
            {
                _customerRepository.DeleteCustomer(customer);
                _customerRepository.Save();
            }
        }

        public bool CustomerExists(int customerId)
        {
            return _customerRepository.GetCustomer(customerId) != null;
        }

        private CustomerDto ToCustomerDto(Customer customer)
        {
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            var customerDto = new CustomerDto
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Phone = customer.Phone
            };
            return customerDto;
        }

        private Customer ToCustomer(CustomerDto customerDto)
        {
            var customer = new Customer
            {
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                Email = customerDto.Email,
                Phone = customerDto.Phone
            };
            return customer;
        }
    }
}
