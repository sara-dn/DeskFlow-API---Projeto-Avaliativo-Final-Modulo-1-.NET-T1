# DeskFlow API — Gestão de Chamados e Helpdesk de TI

## Sobre o projeto

A **DeskFlow API** é uma Web API REST para gerenciamento de chamados de suporte técnico. Ela organiza categorias, solicitações, mudanças de status e interações de acompanhamento, com persistência em SQL Server.

O projeto foi desenvolvido como aplicação avaliativa do módulo Back End .NET. Sua arquitetura separa o recebimento das requisições HTTP, as regras da aplicação e o acesso a dados em Controllers, Services e Repositories.

## Funcionalidades

- Criar, consultar, atualizar e excluir categorias.
- Abrir e consultar chamados.
- Filtrar chamados por status, prioridade e categoria.
- Iniciar e encerrar o atendimento de chamados.
- Registrar interações associadas a chamados.
- Persistir dados relacionais com Entity Framework Core e migrations.
- Retornar uma resposta JSON genérica para exceções não tratadas.

## Tecnologias utilizadas

- C# e ASP.NET Core 10
- Entity Framework Core 10
- SQL Server
- OpenAPI e Swagger UI (ambos disponibilizados no ambiente `Development`)

## Arquitetura

O fluxo principal de uma operação segue **Controller → Service → Repository → AppDbContext/SQL Server**.

| Camada/arquivo | Responsabilidade |
| --- | --- |
| `Controllers/` | Recebe requisições HTTP e retorna resultados e status codes. |
| `Services/` | Coordena operações da aplicação e transforma DTOs em entidades. |
| `Repositories/` | Consulta e persiste entidades com Entity Framework Core. |
| `Models/Entities/` | Define `Category`, `Ticket` e `Interaction`. |
| `Models/DTOs/` | Define os objetos usados para receber dados e formatar respostas. |
| `Data/AppDbContext.cs` | Expõe os conjuntos de entidades do EF Core. |
| `Data/Migrations/` | Mantém o histórico de alterações do esquema do banco. |
| `Middlewares/` | Intercepta exceções não tratadas e gera uma resposta JSON. |
| `Program.cs` | Configura serviços, injeção de dependências e pipeline HTTP. |

### Relacionamentos

- Uma categoria pode possuir vários chamados.
- Um chamado pertence a uma categoria e pode possuir várias interações.

## Pré-requisitos

- .NET SDK 10.
- SQL Server em execução e acessível pela aplicação (por exemplo, SQL Server Express).
- A ferramenta `dotnet-ef` 10.0.12 para aplicar as migrations.

Verifique o SDK e a ferramenta:

```bash
dotnet --version
dotnet ef --version
```

Se `dotnet-ef` não estiver instalado:

```bash
dotnet tool install --global dotnet-ef --version 10.0.12
```

## Configuração e execução

Execute os comandos na pasta que contém `DeskFlow.API.csproj`.

1. Clone o repositório:

   ```bash
   git clone https://github.com/sara-dn/DeskFlow-API---Projeto-Avaliativo-Final-Modulo-1-.NET-T1.git
   cd DeskFlow-API---Projeto-Avaliativo-Final-Modulo-1-.NET-T1
   ```

2. Configure a conexão em `ConnectionStrings:DefaultConnection`. O projeto contém uma configuração local que usa `localhost\SQLExpress` e o banco `deskflowdb`. Altere-a em `appsettings.Development.json` para corresponder ao seu ambiente ou substitua-a sem editar arquivos versionados usando a variável de ambiente `ConnectionStrings__DefaultConnection`. Exemplo para PowerShell:

   ```powershell
   $env:ConnectionStrings__DefaultConnection = "Server=localhost\SQLEXPRESS;Database=deskflowdb;Trusted_Connection=True;TrustServerCertificate=True"
   ```

   Configure o SQL Server com autenticação e permissões adequadas ao seu ambiente. Não adicione senhas ou credenciais pessoais ao repositório.

3. Restaure os pacotes:

   ```bash
   dotnet restore
   ```

4. Crie ou atualize o esquema do banco de dados a partir das migrations do projeto:

   ```bash
   dotnet ef database update
   ```

   O SQL Server precisa estar acessível e a conexão deve apontar para um banco que possa ser criado pelo usuário ou para um banco vazio. O repositório também contém `deskflowdb.sql`, um script de criação direta de banco/tabelas; **não execute esse script e as migrations sobre o mesmo banco**, pois ambos criam tabelas. As migrations são o caminho de atualização do esquema usado pela aplicação.

5. Inicie a aplicação:

   ```bash
   dotnet run
   ```

O perfil HTTP configurado no projeto usa `http://localhost:5075`; o perfil HTTPS usa `https://localhost:7244` e também disponibiliza HTTP em `http://localhost:5075`. Confirme as URLs indicadas pelo terminal ao iniciar.

No ambiente `Development`, a interface Swagger UI é servida em `/swagger` e o documento OpenAPI em `/openapi/v1.json`, relativos à URL base da aplicação.

### Criar uma migration

Depois de alterar o modelo de dados, gere uma migration e aplique-a:

```bash
dotnet ef migrations add NomeDaMigration
dotnet ef database update
```

## Modelo de dados e fluxo do chamado

As entidades são `Category`, `Ticket` e `Interaction`. Ao criar um chamado, a aplicação atribui o status `Open` e registra a data de abertura no servidor. Ao iniciar, define `InProgress`; ao encerrar, define `Closed`, grava a solução enviada e a data de fechamento.

As prioridades aceitas pelo DTO de criação são `low`, `medium` e `high`. Os valores de status usados pela aplicação são `Open`, `InProgress` e `Closed`.

## Endpoints implementados

> **Rotas:** os recursos usam nomes em inglês (`categories`, `tickets` e `interactions`) e estão no plural e em minúsculo. A tabela documenta as rotas configuradas no código.

Todas as rotas estão disponíveis na URL base da aplicação mais o caminho indicado.

### Categorias

| Método | Rota | Comportamento |
| --- | --- | --- |
| `POST` | `/api/categories` | Cria uma categoria. Recebe `{"name":"Hardware"}`. |
| `GET` | `/api/categories` | Lista as categorias. |
| `GET` | `/api/categories/{id}` | Busca uma categoria pelo identificador. |
| `PUT` | `/api/categories/{id}` | Atualiza o nome da categoria. Recebe `{"name":"Hardware"}`. |
| `DELETE` | `/api/categories/{id}` | Solicita a exclusão da categoria. |

### Chamados e interações

| Método | Rota | Comportamento |
| --- | --- | --- |
| `POST` | `/api/tickets` | Abre um chamado. |
| `GET` | `/api/tickets` | Lista chamados; aceita os filtros abaixo, combináveis. |
| `GET` | `/api/tickets/{id}` | Busca um chamado e suas interações. |
| `PATCH` | `/api/tickets/{id}/start` | Define o status do chamado como `InProgress`. |
| `PATCH` | `/api/tickets/{id}/close` | Fecha o chamado com uma solução. |
| `POST` | `/api/tickets/{id}/interactions` | Adiciona uma interação ao chamado. |

Filtros aceitos:

```text
GET /api/tickets?status=Open&priority=high&categoryId=1
```

Exemplo de abertura de chamado:

```http
POST /api/tickets
Content-Type: application/json

{
  "title": "Notebook não liga",
  "description": "O equipamento não inicia.",
  "requesterName": "Ana",
  "priority": "high",
  "categoryId": 1
}
```

Exemplos de início, encerramento e interação:

```http
PATCH /api/tickets/1/start
```

```http
PATCH /api/tickets/1/close
Content-Type: application/json

{
  "solution": "Fonte de alimentação substituída."
}
```

```http
POST /api/tickets/1/interactions
Content-Type: application/json

{
  "author": "Ana",
  "message": "O problema começou hoje pela manhã."
}
```

As buscas por identificador retornam `404 Not Found` quando o registro não existe. As operações de criação retornam `201 Created`; operações bem-sucedidas de consulta e atualização retornam `200 OK`; a exclusão de categoria retorna `204 No Content`. Exceções não tratadas são interceptadas pelo middleware global e retornam `500 Internal Server Error` com JSON contendo a propriedade `error`, sem stack trace.

