<p align="center">
<br>
<br>
   <img src="src/ToolsMarket.App/wwwroot/images/logo.png" width="55%" alt="Ecommerce ASP.NET Core MVC"/>
<br>
<br>
</p> 

<div align=center>

   💻 **See project demo [here](https://ecommerceaspnet.azurewebsites.net/)**
   
</div>

<br>
<br>

## 🚀 Technologies 

- [.NET 6](https://learn.microsoft.com/pt-br/dotnet/)
- [ASP.NET Core](https://learn.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-6.0)
- [ASP.NET Identity](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-7.0&tabs=visual-studio)
- [Entity Framework Core](https://learn.microsoft.com/pt-br/ef/core/)
- [Razor Pages](https://www.heroku.com/)
- [Bootstrap 5](https://sendgrid.com/)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-2019)
- [Azure Cloud Services](https://azure.microsoft.com/en-us/)

## ✨ User Features

- Register new account<br/>
- Login<br/>
- Edit Profile (Change password, username)<br/>
- Product Details<br/>
- Cart system (Add products and Remove, shipping rates), registration required<br/>

## ✨ Administator Features

- CRUD operations on products, categories, and suppliers<br/>

## 👨🏽‍💻 Features in development

- Complete Administrator panel<br/>
- Payment API integration
- Product Search
- Send Email (SendGrid)

## 🤔 How to use?

### Prerequisites

- You will need the latest Visual Studio Community 2022
- Latest version of .NET Core 6
- Entity Framework Core 6

### Installing
Follow these steps to get your development environment set up:

1. Clone this repository: `git clone https://github.com/michaelsribeiro/ASP.NET_Core_Ecommerce.git`

2. If you have Visual Studio after cloning Open solution with your IDE, AspnetRun.Web should be the start-up project. Directly run this project on Visual Studio with `F5 or Ctrl+F5`. You will see index page of project, you can navigate product and category pages and you can perform crud operations on your browser.

3. Ensure your connection strings in appsettings.json point to a local SQL Server instance.

4. To run SQL Server, use `update-database -verbose -context CustomDbContext` and `update-database -verbose -context ApplicationDbContext` to create database and tables.

## ⚙️ Structure of Project

**The project include layers divided by 3 projects**

* Application    
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
* Business  
    * Interfaces
    * Models
    * Notifications
    * Services
* Data
    * Context
    * Mapping
    * Migrations
    * Repository

## 📝 Licence 

- This repo is under MIT Licence. You can see that <a href="https://github.com/michaelsribeiro/ASP.NET_Core_Ecommerce/blob/master/LICENSE.txt"> LICENSE </a> for more details. 😉
