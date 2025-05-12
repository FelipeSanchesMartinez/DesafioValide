🛒 Teste Técnico - Desenvolvedor .NET Fullstack

Este projeto é uma aplicação web ASP.NET MVC com um CRUD completo de Produtos e Categorias, desenvolvida como parte de um teste técnico. O sistema permite o gerenciamento de produtos e categorias com funcionalidades dinâmicas e interface responsiva.
📌 Tecnologias Utilizadas

    .NET 8 

    C# com Entity Framework Core

    SQL Server

    Bulma

    Blazor 

    AutoMapper

    FluentValidation

⚙️ Funcionalidades
📁 Categoria

    Listagem de categorias

    Criação e edição em modal 

    Exclusão com confirmação

    Validações de formulário usando Blazor

📦 Produto

    Listagem de produtos com exibição do nome da categoria

    Filtro por nome do produto e categoria

    Cadastro e edição com seleção de categoria em dropdown

    Exclusão com confirmação

    Validações de formulário usando Blazor

📐 Estrutura do Projeto

    Domain: Entidades e interfaces

    Application: Regras de negócio e serviços

    Infrastructure: Configuração de banco de dados e repositórios

    Web: Projeto principal BLazor  

🗃️ Banco de Dados

O projeto utiliza SQL Server como banco de dados. Você pode criar o banco de dados:
🔸 Usando Migrations

Execute os seguintes comandos no terminal:

dotnet ef database update

Certifique-se de que a ConnectionString esteja corretamente configurada no arquivo appsettings.json.
.
🚀 Como Executar o Projeto
Pré-requisitos

    .NET 8 SDK instalado

    SQL Server Local ou remoto

    Visual Studio 2022+ ou VS Code

Passos

    Clone o repositório

git clone https://github.com/FelipeSanchesMartinez/DesafioValide.git

    Configure a string de conexão no appsettings.json

"ConnectionStrings": {
  "SQLServer": "Server=(localdb)\\mssqllocaldb;Database=valideDB;Integrated Security=SSPI"
}

    Aplique as migrations

dotnet ef database update
ou
Upadate-Database 

    Execute o projeto

dotnet run

📷 Capturas de Tela 
API:
![image](https://github.com/user-attachments/assets/d8084c89-d6c0-4c00-9b2a-d4602e7016e8)

Produtos:
![image](https://github.com/user-attachments/assets/90cbe6a2-d2fb-47e1-a80e-e2166ec17cb4)

Categorias:
![image](https://github.com/user-attachments/assets/ba6cf4ad-56cb-4133-bfae-fbc176680534)

