# Registro de Clientes

Este projeto consiste em dois componentes: **CustomerRegistration** e **CustomerRegistrationApi**, projetados para gerenciar o registro de clientes e fornecer endpoints de API para integra��es externas. Ambos os projetos utilizam um banco de dados em mem�ria para testes e desenvolvimento.

## Funcionalidades
- **Gerenciamento de Clientes**: Adicionar, atualizar e excluir informa��es de clientes.
- **Endpoints de API**: Expor dados de clientes atrav�s de APIs RESTful.
- **Banco de Dados em Mem�ria**: Facilita os testes sem a necessidade de configurar um banco de dados externo.
- **Valida��o de Dados**: Garantir a integridade dos dados com regras de valida��o.

## Tecnologias Utilizadas
- **Linguagem**: C#
- **Framework**: .NET
- **IDE**: Visual Studio
- **Banco de Dados**: Banco de Dados em Mem�ria (Entity Framework Core)

## Instru��es de Configura��o

1. Clone o reposit�rio para sua m�quina local:
   ```bash
   git clone https://github.com/tarciziojunior/CustomerRegistration.git
   ```
2. Abra o arquivo de solu��o `CustomerRegistration.sln` no Visual Studio.
3. Restaure os pacotes NuGet navegando at� o menu "Ferramentas" no Visual Studio e selecionando "Gerenciador de Pacotes NuGet" > "Gerenciar Pacotes NuGet para a Solu��o".
4. Configure os projetos de inicializa��o:
   - V� para "Propriedades da Solu��o".
   - Defina `CustomerRegistration` e `CustomerRegistrationApi` como projetos de inicializa��o.
5. Compile a solu��o usando `Ctrl + Shift + B` ou selecionando "Compilar" > "Compilar Solu��o".
6. Execute os projetos:
   - Pressione `F5` para iniciar a depura��o.
   - A API ser� hospedada localmente, e voc� poder� acess�-la usando ferramentas como Postman ou Swagger.

## Testando com o Banco de Dados em Mem�ria
- Ambos os projetos est�o pr�-configurados para usar um banco de dados em mem�ria para fins de teste.
- Os dados n�o s�o persistidos e ser�o redefinidos toda vez que a aplica��o for reiniciada.
- Essa configura��o garante uma experi�ncia de desenvolvimento leve e sem complica��es.

# Configura��o do Banco de Dados (Em Mem�ria ou SQL Server)

Este projeto est� configurado para utilizar um banco de dados em mem�ria durante o desenvolvimento e o SQL Server , utilizando o padr�o **Adapter Pattern** para facilitar a migra��o entre os ambientes.

## Passos para Configura��o

### Banco de Dados em Mem�ria:
Durante o desenvolvimento, � recomend�vel usar um banco de dados em mem�ria para simplificar o processo e evitar depend�ncias externas.

### Banco de Dados SQL Server:
Quando for necess�rio utilizar o SQL Server , altere a string de conex�o e registre o reposit�rio correspondente na inje��o de depend�ncia.

## Configura��o de Inje��o de Depend�ncia

### Exemplo de Configura��o para Banco de Dados em Mem�ria:
```bash
// Registra o reposit�rio com a inje��o de depend�ncia para mem�ria
builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
```

### Exemplo de Configura��o para Banco de Dados em SqlServer:
```bash
// Registra o reposit�rio com a inje��o de depend�ncia para SQL Server
//builder.Services.AddScoped<ICustomerRepository, SqlServerCustomerRepository>();
```
