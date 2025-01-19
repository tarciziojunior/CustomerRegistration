# Registro de Clientes

Este projeto consiste em dois componentes: **CustomerRegistration** e **CustomerRegistrationApi**, projetados para gerenciar o registro de clientes e fornecer endpoints de API para integrações externas. Ambos os projetos utilizam um banco de dados em memória para testes e desenvolvimento.

## Funcionalidades
- **Gerenciamento de Clientes**: Adicionar, atualizar e excluir informações de clientes.
- **Endpoints de API**: Expor dados de clientes através de APIs RESTful.
- **Banco de Dados em Memória**: Facilita os testes sem a necessidade de configurar um banco de dados externo.
- **Validação de Dados**: Garantir a integridade dos dados com regras de validação.

## Tecnologias Utilizadas
- **Linguagem**: C#
- **Framework**: .NET
- **IDE**: Visual Studio
- **Banco de Dados**: Banco de Dados em Memória (Entity Framework Core)

## Instruções de Configuração

1. Clone o repositório para sua máquina local:
   ```bash
   git clone https://github.com/tarciziojunior/CustomerRegistration.git
   ```
2. Abra o arquivo de solução `CustomerRegistration.sln` no Visual Studio.
3. Restaure os pacotes NuGet navegando até o menu "Ferramentas" no Visual Studio e selecionando "Gerenciador de Pacotes NuGet" > "Gerenciar Pacotes NuGet para a Solução".
4. Configure os projetos de inicialização:
   - Vá para "Propriedades da Solução".
   - Defina `CustomerRegistration` e `CustomerRegistrationApi` como projetos de inicialização.
5. Compile a solução usando `Ctrl + Shift + B` ou selecionando "Compilar" > "Compilar Solução".
6. Execute os projetos:
   - Pressione `F5` para iniciar a depuração.
   - A API será hospedada localmente, e você poderá acessá-la usando ferramentas como Postman ou Swagger.

## Testando com o Banco de Dados em Memória
- Ambos os projetos estão pré-configurados para usar um banco de dados em memória para fins de teste.
- Os dados não são persistidos e serão redefinidos toda vez que a aplicação for reiniciada.
- Essa configuração garante uma experiência de desenvolvimento leve e sem complicações.

# Configuração do Banco de Dados (Em Memória ou SQL Server)

Este projeto está configurado para utilizar um banco de dados em memória durante o desenvolvimento e o SQL Server , utilizando o padrão **Adapter Pattern** para facilitar a migração entre os ambientes.

## Passos para Configuração

### Banco de Dados em Memória:
Durante o desenvolvimento, é recomendável usar um banco de dados em memória para simplificar o processo e evitar dependências externas.

### Banco de Dados SQL Server:
Quando for necessário utilizar o SQL Server , altere a string de conexão e registre o repositório correspondente na injeção de dependência.

## Configuração de Injeção de Dependência

### Exemplo de Configuração para Banco de Dados em Memória:
```bash
// Registra o repositório com a injeção de dependência para memória
builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
```

### Exemplo de Configuração para Banco de Dados em SqlServer:
```bash
// Registra o repositório com a injeção de dependência para SQL Server
//builder.Services.AddScoped<ICustomerRepository, SqlServerCustomerRepository>();
```
