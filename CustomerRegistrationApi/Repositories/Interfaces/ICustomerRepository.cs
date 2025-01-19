using CustomerRegistrationApi.Domain;

namespace CustomerRegistrationApi.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Adiciona um novo cliente ao repositório.
        /// </summary>
        /// <param name="customer">Objeto do cliente a ser adicionado.</param>
        /// <returns>Uma tarefa assíncrona concluída quando o cliente for adicionado.</returns>
        Task AddCustomerAsync(Customer customer);

        /// <summary>
        /// Busca um cliente no repositório pelo e-mail.
        /// </summary>
        /// <param name="email">E-mail do cliente a ser buscado.</param>
        /// <returns>O cliente correspondente ou null se não for encontrado.</returns>
        Task<Customer?> GetCustomerByEmailAsync(string email);

        /// <summary>
        /// Atualiza os dados de um cliente existente no repositório.
        /// </summary>
        /// <param name="email">E-mail do cliente a ser atualizado.</param>
        /// <param name="customer">Objeto com os novos dados do cliente.</param>
        /// <returns>True se o cliente foi atualizado, False caso contrário.</returns>
        Task<bool> UpdateCustomerAsync(string email, Customer customer);

        /// <summary>
        /// Remove um cliente do repositório pelo e-mail.
        /// </summary>
        /// <param name="email">E-mail do cliente a ser removido.</param>
        /// <returns>True se o cliente foi removido, False caso contrário.</returns>
        Task<bool> DeleteCustomerAsync(string email);

        /// <summary>
        /// Obtém todos os clientes armazenados no repositório.
        /// </summary>
        /// <returns>Uma lista enumerável de todos os clientes.</returns>
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
    }
}
