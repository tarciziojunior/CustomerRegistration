using CustomerRegistrationApi.Common;
using CustomerRegistrationApi.Request.Customer;

namespace CustomerRegistrationApi.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Result<bool>> AddCustomerAsync(CustomerRequest customerRequest);
        Task<Result<CustomerRequest>> GetCustomerByEmailAsync(string email);
        Task<Result<bool>> UpdateCustomerAsync(string email, CustomerRequest customerRequest);
        Task<Result<bool>> DeleteCustomerAsync(string email);
        Task<Result<IEnumerable<CustomerRequest>>> GetAllCustomersAsync();
    }
}
