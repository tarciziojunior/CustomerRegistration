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
   git clone https://github.com/yourusername/CustomerRegistration.git
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

