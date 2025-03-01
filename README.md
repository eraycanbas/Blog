# Blog Project

This project is built using **Domain-Driven Design (DDD)** architecture to create a scalable and maintainable blog platform. It follows the **CQRS** pattern and utilizes **MediatR** to separate commands and queries efficiently.

## 📌 Technologies
The key technologies used in this project are:

- **.NET 7+** (Backend)
- **C#**
- **Entity Framework Core** (PostgreSQL)
- **PostgreSQL** (Database)
- **Elasticsearch** (For advanced search and logging)
- **MediatR** (For command & query handling)
- **FluentValidation** (For data validation)
- **Unit of Work & Repository Pattern** (For database operations)

## 📂 Layered Architecture
The project follows **DDD principles** and consists of the following layers:

```
📂 Blog.Api          → API layer (Controllers)
📂 Blog.Application  → Business logic (Commands, Queries, Services, Validations)
📂 Blog.Domain       → Entities, Aggregates, Value Objects, Domain Events
📂 Blog.Infrastructure → Data access, Repository, Unit of Work, Elasticsearch integration
```

## 🚀 Setup & Run
Follow these steps to set up and run the project:

### 1️⃣ Install Dependencies
```sh
 dotnet restore
```

### 2️⃣ Apply Database Migrations
```sh
 dotnet ef database update
```

### 3️⃣ Start Elasticsearch
Ensure Elasticsearch is running.
```sh
docker-compose up -d elasticsearch
```

### 4️⃣ Run the API
```sh
 dotnet run --project Blog.Api
```

Once the API is running, you can test it using **Swagger UI**: 
```
http://localhost:5000/swagger
```

## 🎯 Contributing
If you would like to contribute, feel free to open a **Pull Request** or **Issue**. We welcome any suggestions! 😊

## 📄 License
This project is licensed under the **MIT License**. For more details, check the `LICENSE` file.


