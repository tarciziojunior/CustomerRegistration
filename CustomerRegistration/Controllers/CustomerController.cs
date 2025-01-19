using CustomerRegistration.Common;
using CustomerRegistration.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace CustomerRegistration.Controllers
{
    public class CustomerController(HttpClient httpClient, IConfiguration configuration) : Controller
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly string URL = configuration["Url_Customer"] ?? string.Empty;

        public async Task<IActionResult> Index()
        {
            try
            {
                // Fazendo a requisição GET para a API
                var response = await _httpClient.GetAsync(URL);

                // Verificando se a resposta foi bem-sucedida
                if (response.IsSuccessStatusCode)
                {
                    // Lendo o conteúdo da resposta como string
                    var content = await response.Content.ReadAsStringAsync();

                    // Deserializando a resposta JSON para a lista de clientes
                    var customers = JsonConvert.DeserializeObject<List<Customer>>(content);

                    if (customers == null)
                        return View(new List<CustomerIndexViewModel>());

                    var customerIndexViewModel = customers.Select(customer =>
                    {
                        return new CustomerIndexViewModel(customer.Name, customer.Email, customer.Addresses,
                             customer.CompanyFile.Data);
                    }).ToList();
                    // Passando os dados para a View
                    return View(customerIndexViewModel);


                }
                else
                {
                    // Se a requisição falhar, pode-se retornar uma mensagem de erro
                    ViewBag.ErrorMessage = await GetErrorMessage(response);
                    return View(new List<CustomerIndexViewModel>());
                }
            }
            catch (Exception ex)
            {
                // Se ocorrer algum erro ao tentar acessar a API
                ViewBag.ErrorMessage = $"Erro ao acessar a API: {ex.Message}";
                return View(new List<CustomerIndexViewModel>());
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                ViewBag.ErrorMessage = "Email não pode ser nulo ou vazio.";
                return Json(new { success = false, message = "Email não pode ser nulo ou vazio." });
            }

            try
            {
                // Envia a solicitação DELETE
                var response = await _httpClient.DeleteAsync(URL + email);

                // Verifica se a operação foi bem-sucedida (status HTTP 200-299)
                if (response.IsSuccessStatusCode)
                {                  
                    return Json(new { success = true, message = $"Cliente com email {email} foi excluído com sucesso." });
                }
                else
                {
                    ViewBag.ErrorMessage = await GetErrorMessage(response);
                    return Json(new { success = false, message = ViewBag.ErrorMessage });
                }
            }
            catch (Exception ex)
            {
                // Log ou tratamento de exceções                
                ViewBag.ErrorMessage = $"Exceção ao excluir cliente: {ex.Message}";
                return Json(new { success = false, message = $"Erro ao excluir cliente: {ex.Message}" });
            }
        }
        // Exibe o formulário de criação de um novo cliente
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(customerViewModel);
            }

            try
            {
                if (customerViewModel.Logo == null)
                {
                    ViewBag.ErrorMessage = "Erro ao upload do Arquivo";
                    return View(customerViewModel);
                }
                // Converte o arquivo em array de bytes
                string fileData = FileHelper.ConvertToBase64(customerViewModel.Logo);

                // Aqui você pode salvar o `fileData` em um banco de dados ou outro local
                // Exemplo: Salvando o arquivo em um modelo de entidade
                CompanyFile companyFile = new(customerViewModel.Logo.FileName,
                    customerViewModel.Logo.ContentType,
                    fileData);
                var customer = new Customer(customerViewModel.Name, customerViewModel.Email, customerViewModel.Addresses, companyFile);

                var content = new StringContent(JsonConvert.SerializeObject(customer), System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(URL, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = await GetErrorMessage(response);
                    return View(customerViewModel);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Erro: {ex.Message}";
                return View(customerViewModel);
            }
        }
        // Exibe o formulário para edição cliente
        [HttpGet]
        public async Task<IActionResult> Edit(string email)
        {
            // Fazendo a requisição GET para a API
            var response = await _httpClient.GetAsync(URL + email);

            // Verificando se a resposta foi bem-sucedida
            if (response.IsSuccessStatusCode)
            {
                // Lendo o conteúdo da resposta como string
                var content = await response.Content.ReadAsStringAsync();

                // Deserializando a resposta JSON para a lista de clientes
                var customer = JsonConvert.DeserializeObject<Customer>(content);

                if (customer == null)
                    return View(new CustomerEditModel());

                return View(new CustomerEditModel(customer.Name, customer.Email, customer.Addresses,
                        customer.CompanyFile.Data, customer.CompanyFile.ContentType, customer.CompanyFile.FileName));
            }
            else
            {
                ViewBag.ErrorMessage = await GetErrorMessage(response);                   
                return View(new List<CustomerIndexViewModel>());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CustomerEditModel customerViewModel)
        {           
            try
            {
                CompanyFile companyFile = new(
                    customerViewModel.FileName,
                    customerViewModel.ContentType,
                    customerViewModel.Base64Image);
                if (customerViewModel.Logo != null)
                {


                    // Converte o arquivo em array de bytes
                    string fileData = FileHelper.ConvertToBase64(customerViewModel.Logo);

                    // Aqui você pode salvar o `fileData` em um banco de dados ou outro local
                    // Exemplo: Salvando o arquivo em um modelo de entidade
                    companyFile = new(customerViewModel.Logo.FileName,
                        customerViewModel.Logo.ContentType,
                        fileData);
                }
                var customer = new Customer(customerViewModel.Name, customerViewModel.Email, customerViewModel.Addresses, companyFile);

                var content = new StringContent(JsonConvert.SerializeObject(customer), System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(URL + customer.Email, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = await GetErrorMessage(response);
                    return View(customerViewModel);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Erro: {ex.Message}";
                return View(customerViewModel);
            }
        }
        private static async Task<string> GetErrorMessage(HttpResponseMessage response)
        {
            var errorMessage = await response.Content.ReadAsStringAsync();
            return $"Erro {response.StatusCode}: {errorMessage}";
        }
    }
}
