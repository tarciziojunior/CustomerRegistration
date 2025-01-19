# API Project CustomerRegistrationApi

## Descrição

Este projeto é uma API desenvolvida com .NET Core para cadastrar Cliente, preparada para utilizar um banco de dados em memória por padrão. No entanto, também pode ser configurada para usar um banco de dados SQL Server, caso necessário.

---

## Configuração do Banco de Dados

### Banco de Dados em Memória
Por padrão, o projeto utiliza um banco de dados em memória para facilitar o desenvolvimento e os testes.

### Banco de Dados SQL Server
Se desejar utilizar o SQL Server como banco de dados, siga as etapas abaixo:

#### Criação das Migrações

Execute o seguinte comando para criar as migrações:

```bash
 dotnet ef migrations add InitialMigration --context ApplicationDbContext
```

Substitua `InitialMigration` pelo nome desejado para a migração (por exemplo, `customer`).

#### Atualização do Banco de Dados

Aplique as migrações ao banco de dados utilizando o seguinte comando:

```bash
 dotnet ef database update --context ApplicationDbContext
```

#### Alternando Entre Banco de Dados em Memória e SQL Server

Para alterar o banco de dados padrão (em memória) para o SQL Server:

1. Ajuste a configuração no arquivo `appsettings.json` ou diretamente no código da API.
2. Certifique-se de configurar corretamente a string de conexão.

##### Exemplo de String de Conexão no `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=seu_servidor;Database=sua_base_de_dados;User Id=seu_usuario;Password=sua_senha;"
  }
}
```

---

## Dependências Necessárias

Certifique-se de que as dependências abaixo estejam instaladas no projeto:

- **Entity Framework Core**
- **Entity Framework Core Tools**
- **Provider do SQL Server para Entity Framework Core**

#### Instalação das Dependências:

```bash
 dotnet add package Microsoft.EntityFrameworkCore
 dotnet add package Microsoft.EntityFrameworkCore.Tools
 dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

---

## Executando o Projeto

Para rodar a API, execute o seguinte comando na raiz do projeto:

```bash
 dotnet run
```

A API estará disponível no endpoint configurado, geralmente:

- `https://localhost:7240`
- `http://localhost:7240`

---
