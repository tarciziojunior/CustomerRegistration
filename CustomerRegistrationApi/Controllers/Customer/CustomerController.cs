using CustomerRegistrationApi.Request.Customer;
using CustomerRegistrationApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRegistrationApi.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomerService customerService) : ControllerBase
    {
        private readonly ICustomerService _customerService = customerService;

        // POST api/customer
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerRequest customerRequest)
        {
            var result = await _customerService.AddCustomerAsync(customerRequest);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message); // Retorna um erro se a operação falhar
            }

            return CreatedAtAction(nameof(GetCustomerByEmail), new { email = customerRequest.Email }, result.Data);
        }

        // GET api/customer/{email}
        [HttpGet("{email}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCustomerByEmail(string email)
        {
            var result = await _customerService.GetCustomerByEmailAsync(email);

            if (!result.IsSuccess)
            {
                return NotFound(result.Message); // Retorna "Not Found" se o cliente não for encontrado
            }

            return Ok(result.Data); // Retorna o cliente encontrado
        }

        // PUT api/customer/{email}
        [HttpPut("{email}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateCustomer(string email, [FromBody] CustomerRequest customerRequest)
        {
            var result = await _customerService.UpdateCustomerAsync(email, customerRequest);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message); // Retorna um erro se a operação falhar
            }

            return Ok(result.Data); // Retorna a confirmação de sucesso
        }

        // DELETE api/customer/{email}
        [HttpDelete("{email}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteCustomer(string email)
        {
            var result = await _customerService.DeleteCustomerAsync(email);

            if (!result.IsSuccess)
            {
                return NotFound(result.Message); // Retorna "Not Found" se o cliente não for encontrado
            }

            return Ok(result.Data); // Retorna a confirmação de sucesso
        }

        // GET api/customer
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllCustomers()
        {
            var result = await _customerService.GetAllCustomersAsync();

            if (!result.IsSuccess)
            {
                return NoContent(); // Retorna "No Content" se não houver clientes
            }

            return Ok(result.Data); // Retorna todos os clientes
        }
    }
}
