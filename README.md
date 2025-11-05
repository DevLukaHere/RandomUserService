## 🏗️ Project Overview

The application periodically fetches user data from an external API (randomuser.me) and saves it into a local database using a background scheduler.  
It also exposes REST API endpoints to view stored users.

## 🧩 Architecture

This project follows a **Clean Architecture** approach.

## 🔹 Layer Responsibilities

**Core** - Contains domain entities (`User`), service logic (`UserService`), and interfaces  
**Infrastructure** - Handles external API calls (`RandomUserApiClient`), data persistence (`AppDbContext`, `UserRepository`), and DTO mappings  
**API** - The entry point of the application. Contains controllers, DI setup, background `Scheduler`, and configuration  
**Tests** - NUnit-based Unit & Integration tests for both service logic and EF persistence  

## 🧠 Technologies Used

- **.NET 8 / ASP.NET Core Web API**
- **Entity Framework Core** (SQLite provider)
- **NUnit** (Unit + Integration testing)
- **Dependency Injection** (Microsoft.Extensions.DependencyInjection)
- **Swagger / Swashbuckle** (API documentation)
- **HttpClientFactory** (typed clients for external API calls)

## ⚙️ Configuration

### 🗂️ `appsettings.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=users.db"
  },
  "Scheduler": {
    "IntervalSeconds": 60
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

## 🗂️ How to Run

### Clone the Repository

git clone https://github.com/DevLukaHere/RandomUserService.git
cd RandomUserService

### Restore Dependencies

dotnet restore

### Apply Database Migrations

cd RandomUserService.Api  
dotnet ef database update  

### Run the Application

dotnet run --project RandomUserService.Api

The app will:
- Start an HTTP server on https://localhost:7235
- Run the background scheduler that fetches users from randomuser.me at configured intervals (scheduler is paused by default to avoid requests spam, can be started using API)
- Automatically generate the SQLite database file (users.db)

### Open Swagger

https://localhost:7235/swagger

You’ll see available endpoints:

GET /api/users → Returns all users  
GET /api/users/{id} → Returns a user by ID  
POST /api/scheduler/start → Starts background fetching  
POST /api/scheduler/pause → Pauses background fetching  
POST /api/scheduler/resume → Resumes fetching  
