using AutoMapper;
using CustomerRegistrationApi.Common;
using CustomerRegistrationApi.Domain;
using CustomerRegistrationApi.Repositories.Interfaces;
using CustomerRegistrationApi.Request.Customer;
using CustomerRegistrationApi.Services.Interfaces;

namespace CustomerRegistrationApi.Services
{
    public class CustomerService(ICustomerRepository customerRepository, IMapper mapper) : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<bool>> AddCustomerAsync(CustomerRequest customerRequest)
        {
            // Mapeia CustomerRequest para Customer
            var customer = _mapper.Map<Customer>(customerRequest);

            var existingCustomer = await _customerRepository.GetCustomerByEmailAsync(customer.Email);
            if (existingCustomer != null)
            {
                return Result<bool>.Failure("Já existe um cliente com este e-mail.");
            }

            await _customerRepository.AddCustomerAsync(customer);
            return Result<bool>.Success(true, "Cliente adicionado com sucesso.");
        }

        public async Task<Result<CustomerRequest>> GetCustomerByEmailAsync(string email)
        {
            var customer = await _customerRepository.GetCustomerByEmailAsync(email);
            if (customer == null)
            {
                return Result<CustomerRequest>.Failure("Cliente não encontrado.");
            }

            // Mapeia Customer para CustomerRequest
            var customerRequest = _mapper.Map<CustomerRequest>(customer);
            return Result<CustomerRequest>.Success(customerRequest, "Cliente recuperado com sucesso.");
        }

        public async Task<Result<bool>> UpdateCustomerAsync(string email, CustomerRequest customerRequest)
        {
            var existingCustomer = await _customerRepository.GetCustomerByEmailAsync(email);
            if (existingCustomer == null)
            {
                return Result<bool>.Failure("Cliente não encontrado.");
            }

            // Mapeia CustomerRequest para Customer
            var customer = _mapper.Map<Customer>(customerRequest);
            await _customerRepository.UpdateCustomerAsync(email, customer);
            return Result<bool>.Success(true, "Cliente atualizado com sucesso.");
        }

        public async Task<Result<bool>> DeleteCustomerAsync(string email)
        {
            var existingCustomer = await _customerRepository.GetCustomerByEmailAsync(email);
            if (existingCustomer == null)
            {
                return Result<bool>.Failure("Cliente não encontrado.");
            }

            await _customerRepository.DeleteCustomerAsync(email);
            return Result<bool>.Success(true, "Cliente excluído com sucesso.");
        }

        public async Task<Result<IEnumerable<CustomerRequest>>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllCustomersAsync();
            // Mapeia a lista de Customers para uma lista de CustomerRequests
            var customerRequests = _mapper.Map<IEnumerable<CustomerRequest>>(customers);
            return Result<IEnumerable<CustomerRequest>>.Success(customerRequests, "Clientes recuperados com sucesso.");
        }
    }
}
