# 💜 Big Purple Bank

**Big Purple Bank** is a secure (not so) and scalable banking system API built with **.NET 8**, providing core banking functionalities, request validation, standardized responses, and automated API documentation with Swagger. The system is designed with testability in mind, including both unit (and integration*) tests.

---

## 🚀 Features

- 🔒 Secure, extensible API endpoints
- ✅ Model validation and structured error handling
- 📄 Auto-generated Swagger UI for easy API exploration
- 🧪 Unit (and integration*) tests for reliable code quality
- 🧱 Modular and layered architecture
- 📦 Follows RESTful conventions with versioning support

---

## 🧰 Tech Stack

- **.NET 8**
- **ASP.NET Core Web API**
- **Swagger / Swashbuckle**
- **xUnit / NUnit**
- **Moq**
- **EF Core**
- **Database** (optional for storage*)


---

## 🏛️ Architecture
- **Azure Resource Group**
- **App Service Plan** (F1)
- **Azure App Service** (Web App)
- **Github Actions** (CI/CD pipelines)
- **Github Secrets** (publish profile)

---

## 🧠 Domain
```
bigpurplebank.azurewebsites.net
```
To access swagger, ...net/swagger

---

## 🧪 Running Tests

To run all tests:

```bash
dotnet test
```

---

## 📦 API Documentation

The Swagger UI is available after running the project:

```
https://localhost:<port>/swagger
```

It provides an interactive interface for testing all available endpoints and viewing their request/response structure.

---

## 📄 Sample Error Response

Standardized error response for failed requests:

```json
{
  "errors": [
    {
        "code": "InternalServerError",
        "title": "Internal Server Error",
        "detail": "An unexpected error occurred."
    }
  ]
}
```

---

## 🛠️ Development

To run the app locally:

```bash
dotnet run --project BigPurpleBank
```

To restore dependencies:

```bash
dotnet restore
```

---

## 📫 Contact

For support or questions, open an issue in the repo.

***PS: integration tests and database configuration was not included for this demo***
