# JobPortalAPI

A RESTful API built with ASP.NET Core (.NET 9) for managing job openings, departments, and locations.

## 🔧 Technologies Used

- ASP.NET Core 9
- Entity Framework Core
- SQL Server
- xUnit (unit testing)
- Swagger / OpenAPI

## 📦 Features

- Create, update, view, and list job postings
- Manage department and location masters
- Paginated and filterable job list
- API documentation with Swagger UI
- Unit tests using EF Core In-Memory DB

## 🛠 Database Setup (EF Core)

To create the database using Entity Framework Core:

1. Ensure SQL Server is installed and running.
2. Update the connection string in `appsettings.json`.
3. Run the following command to apply the initial migration and create the database:

```bash
dotnet ef database update

Alternatively, run the script `InitDbScript.sql` in SQL Server Management Studio to create all tables manually.

## 🚀 Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/datta2104/JobPortalAPI.git
cd JobPortalAPI
