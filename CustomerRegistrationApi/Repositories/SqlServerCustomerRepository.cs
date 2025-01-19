using CustomerRegistrationApi.Domain;
using CustomerRegistrationApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CustomerRegistrationApi.Repositories
{
    public class SqlServerCustomerRepository(ApplicationDbContext context) : ICustomerRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task AddCustomerAsync(Customer customer)
        {
            ArgumentNullException.ThrowIfNull(customer);

            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer?> GetCustomerByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));

            return await _context.Customers
                    .Include(c => c.Addresses)
                    .Include(c => c.CompanyFile)
                    .FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<bool> UpdateCustomerAsync(string email, Customer customer)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));

            var existingCustomer = await _context.Customers
                                                  .FirstOrDefaultAsync(c => c.Email == email);

            if (existingCustomer == null)
                return false;

            existingCustomer.Name = customer.Name;
            existingCustomer.Addresses = customer.Addresses;
            existingCustomer.CompanyFile = customer.CompanyFile;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCustomerAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));

            var customer = await _context.Customers
                                         .FirstOrDefaultAsync(c => c.Email == email);

            if (customer == null)
                return false;

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers
               .Include(c => c.Addresses)
               .Include(c => c.CompanyFile)
               .ToListAsync();
        }
    }
}
