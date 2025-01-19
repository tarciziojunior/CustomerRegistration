# Razor MVC Project - README

## Descrição

Este projeto é uma aplicação web desenvolvida com o framework ASP.NET Core usando o padrão MVC com Razor Pages. Ele é projetado para ser fácil de configurar e usar, permitindo a criação de aplicações dinâmicas baseadas em Model-View-Controller.

---

## Configuração do Projeto

### Requisitos

Antes de iniciar, certifique-se de que os seguintes requisitos estejam atendidos:

- **SDK do .NET Core**: Versão 6.0 ou superior.
- **IDE Recomendada**: Visual Studio 2022 ou superior.

### Configuração Inicial

1. Clone este repositório:

   ```bash
   git clone <URL_DO_REPOSITORIO>
   ```

2. Navegue até o diretório do projeto:

   ```bash
   cd <NOME_DO_PROJETO>
   ```

3. Restaure as dependências do projeto:

   ```bash
   dotnet restore
   ```


---

## Estrutura do Projeto

- **Models**: Contém as classes que representam os dados da aplicação.
- **Views**: Contém as páginas Razor (.cshtml) para exibir informações ao usuário.
- **Controllers**: Contém a lógica da aplicação e controla a interação entre Models e Views.
- **wwwroot**: Contém arquivos estáticos como CSS, JavaScript e imagens.

---

## Executando o Projeto

1. Compile e inicie o servidor de desenvolvimento:

   ```bash
   dotnet run
   ```

2. Acesse a aplicação no navegador pelos endpoints padrão:

   - `https://localhost:7298`
   - `http://localhost:7298`

---


