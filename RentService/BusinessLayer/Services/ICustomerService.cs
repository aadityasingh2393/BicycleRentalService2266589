using BusinessLayer.Models;

namespace BicycleRentalSystem.RentService.BusinessLayer.Services
{
    public interface ICustomerService
    {
        CustomerDto GetCustomer(int customerId);
        IEnumerable<CustomerDto> GetAllCustomers();
        void AddCustomer(CustomerDto customer);
        void UpdateCustomer(CustomerDto customer);
        void DeleteCustomer(int customerId);
        bool CustomerExists(int customerId);
    }
}
