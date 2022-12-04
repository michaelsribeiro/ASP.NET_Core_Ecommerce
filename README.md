<p align="center">
<br>
<br>
   <img src="src/ToolsMarket.App/wwwroot/images/logo.png" width="55%" alt="Ecommerce ASP.NET Core MVC"/>
<br>
<br>
</p> 

<div align=center>

   💻 **Veja o projeto em produção [aqui](https://ecommerceaspnet.azurewebsites.net/)**
   
</div>

<br>
<br>

## Recursos de Usuário

- Página de detalhes de produto
- Carrinho de compras (Adicionar ou remover produtos, cálculo de frete), necessário registro para acessar
- Cadastrar contas / Login
- Perfil (Trocar senha, username)

## Recursos de Administrador

- Operações de CRUD em produto, categoria e fornecedor

## Como usar?

### Pré-requisitos

- Necessário instalar a versão mais recente do Visual Studio Community 2022;
- Versão mais recente (ou a mais estável) do .NET 6;
- Entity Framework Core 6

### Instalação
Siga os passos abaixo para ter acesso ao seu ambiente de desenvolvimento:

1. Clone o repositório: `git clone https://github.com/michaelsribeiro/ASP.NET_Core_Ecommerce.git`;

2. Configure a string de conexão no arquivo **appsettings.json** apontando para o seu banco de dados SQL Server;

3. Para criar o banco de dados SQL Server e suas respectivas tabelas, abra o **Package Manager Console** em seu Visual Studio e digite os comandos: 
    - Criação das tabelas do Identity: 
        ```csharp
            update-database -verbose -context CustomDbContext
        ```

    - Criação das tabelas da camada de negócios: 
        ```csharp
            update-database -verbose -context ApplicationDbContext
        ```

4. Pressione `F5 ou Ctrl+F5` para rodar o projeto no seu navegador.

## Estrutura do Projeto

**O Projeto foi dividido em camadas, utilizando 3 projetos:**

* **Application**    
    * Properties  
    * wwwroot
    * Areas
    * AutoMapper
    * Controllers
    * Data
    * Extensions
    * ViewComponents
    * ViewModels
    * Views
* **Business**  
    * Interfaces
    * Models
    * Notifications
    * Services
* **Data**
    * Context
    * Mapping
    * Migrations
    * Repository

### Arquitetura de Camadas
Foi implementada a aquitetura de camadas juntamente com o padrão **MVC (Model-View-Controller)** que foca na separação de resposabilidades dentro de um projeto web, cada camada é uma porção de código que realiza uma tarefa específica, possuindo a reponsabilidade de interagir com outras camadas para realizar um objetivo específico.

### Application
Camada responsável por apresentar as páginas da aplicação que foram construídas com **Razor Pages**, esta é a interface onde o usuário interage com a aplicação. 
Os dados apresentados nesta camada são oriundos da camada Business, que envia os dados para a camada de apresentação através da lib **AutoMapper**.

### Business 
A camada de negócios contém as classes (**entidades**) e validações (**regras de negócio**), que são feitas antes de realizar chamadas aos métodos da camada de acesso a dados, garantindo que os dados sejam informados de forma correta.

#### Models (entidades)
A criação das tabelas é feita através do **ORM (Object Relational Mapping) Entity Framework Core** utilizando o fluxo de trabalho **Code First**, que cria as tabelas do banco de dados com base nas entidades. <br/>

Você pode saber mais sobre o Code First [neste](https://www.devmedia.com.br/entity-framework-code-first/29705) link.

Abaixo é possível visualizar um exemplo de entidade do projeto.<br/>

```csharp
 public class Produto : Entity
 {
     public Produto(Guid categoriaId, Guid fornecedorId, string nome, string? descricao, string marca, int quantidade, decimal valorUnitario, string imagem)
     {
         CategoriaId = categoriaId;
         FornecedorId = fornecedorId;
         Nome = nome;
         Descricao = descricao;
         Marca = marca;
         DefinirQuantidade(quantidade);
         ValorUnitario = valorUnitario;
         Imagem = imagem;
         DefinirStatus(quantidade);
     }

     public Guid CategoriaId { get; private set; }
     public Guid FornecedorId { get; private set; }
     public string Nome { get; private set; }
     public string? Descricao { get; private set; }
     public string Marca { get; private set; }
     public int Quantidade { get; private set; }
     public decimal ValorUnitario { get; private set; }
     public string Imagem { get; private set; }
     public StatusProduto Status { get; private set; }

     public Categoria Categoria { get; private set; }
     public IEnumerable<Categoria>? Categorias { get; private set; }

     public Fornecedor Fornecedor { get; private set; }
     public IEnumerable<Fornecedor>? Fornecedores { get; private set; }
 }
```

### Data
Camada de acesso a dados, onde a informação é armazenada e retornada da fonte de dados (**SQL Server**), a informação é passada de volta para a camada de negócio e enfim apresentada ao usuário.

#### Context (DbContext)
Classe integrante do **Entity Framework** que representa uma sessão com o banco de dados que pode ser usada para consultar e salvar entidades em um banco de dados.

Para utilizar o contexto é preciso criar uma classe que herde de **DbContext**, no caso deste projeto foi criada uma classe nomeada de **CustomDbContext**, neste contexto são incluídas as propriedades `DbSet<TEntity>` para cada model (**entidade**).<br/>

Abaixo é possível visualizar a classe de contexto do projeto.<br/>

```csharp
public class CustomDbContext : DbContext
{
    public CustomDbContext(DbContextOptions<CustomDbContext> options) : base(options)  { }
    
    public DbSet<ItemPedido> ItensPedido { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {        
        base.OnModelCreating(modelBuilder);
    }
}
```

#### Migrations
Para criar uma nova migration, abra o **Package Manager Console** e digite os seguintes comandos:

1. Para adicionar uma nova migration do Identity: 
    ```csharp
        add-migration nomeMigration -verbose -context ApplicationDbContext
    ```

2. Para adicionar uma nova migration da camada de negócios: 
    ```csharp
        add-migration nomeMigration -verbose -context CustomDbContext
    ```

## Tecnologias 

- [.NET 6](https://learn.microsoft.com/pt-br/dotnet/)
- [ASP.NET Core](https://learn.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-6.0)
- [ASP.NET Identity](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-7.0&tabs=visual-studio)
- [Entity Framework Core](https://learn.microsoft.com/pt-br/ef/core/)
- [Razor Pages](https://www.heroku.com/)
- [Bootstrap 5](https://sendgrid.com/)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-2019)
- [Azure Cloud Services](https://azure.microsoft.com/en-us/)

## Em Desenvolvimento

- Painel de Administração
- Integração com API de pagamentos
- Busca de Produtos ou Categorias
- Envio de Email (**SendGrid**)

## Deixe uma Estrela ⭐
Se você gostou deste projeto ou se te ajudou em algo, por favor, **deixe uma estrela**. Caso queira contribuir, basta dar um **fork** no projeto e enviar seus **pull-requests**. Caso encontre algum problema, por favor, abra uma **issue**.

## Licença

- Este repositório está sob a Licença MIT. Mais informações: <a href="https://github.com/michaelsribeiro/ASP.NET_Core_Ecommerce/blob/master/LICENSE.txt"> LICENÇA </a>
