using CustomerRegistrationApi.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CustomerRegistrationApi.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IConfiguration configuration) : ControllerBase    
    {
        private readonly IConfiguration configuration = configuration;

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest model)
        {
            // Validação simples (use um banco de dados em produção)
            if (model.Username == "admin" && model.Password == "123")
            {
                var secretKey = this.configuration["secretkey"]??string.Empty;
                var tokenHandler = new JwtSecurityTokenHandler();
                var chaveSimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                // Data de expiração do token
                var tokenExpiration = DateTime.UtcNow.AddHours(1);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(
                    [
                    new Claim(ClaimTypes.Name, model.Username),
                    new Claim(ClaimTypes.Role, "Admin") // Função do usuário
                ]),
                    Expires = tokenExpiration, // Validade do token
                    SigningCredentials = new SigningCredentials(chaveSimetrica, SecurityAlgorithms.HmacSha256Signature),
                    Issuer = this.configuration["ValidIssuer"] ?? string.Empty,
                    Audience = this.configuration["ValidAudience"] ?? string.Empty,
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);               
                return Ok(new
                {
                    Token = tokenHandler.WriteToken(token),
                  
                    Expiration = tokenExpiration
                });               
            }
            return Unauthorized("Credenciais inválidas.");
        }
    }
}
