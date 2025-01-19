using CustomerRegistrationApi.Domain;
using CustomerRegistrationApi.Repositories.Interfaces;
using System.Collections.Concurrent;

namespace CustomerRegistrationApi.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private static readonly ConcurrentDictionary<string, Customer> _customers = new();

        public Task AddCustomerAsync(Customer customer)
        {
            ArgumentNullException.ThrowIfNull(customer);
            if (string.IsNullOrEmpty(customer.Email))
                throw new ArgumentException("Customer email cannot be null or empty.");

            if (!_customers.TryAdd(customer.Email, customer))
                throw new InvalidOperationException($"Customer with email {customer.Email} already exists.");

            return Task.CompletedTask;
        }

        public Task<Customer?> GetCustomerByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));

            _customers.TryGetValue(email, out var customer);
            return Task.FromResult(customer);
        }

        public Task<bool> UpdateCustomerAsync(string email, Customer customer)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));

            if (!_customers.ContainsKey(email))
                return Task.FromResult(false);

            _customers[email] = customer;
            return Task.FromResult(true);
        }

        public Task<bool> DeleteCustomerAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));

            return Task.FromResult(_customers.TryRemove(email, out _));
        }

        public Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return Task.FromResult(_customers.Values.AsEnumerable());
        }
    }
}
