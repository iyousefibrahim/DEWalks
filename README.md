# DEWalks API

## Overview
DEWalks API is a RESTful web API built using **.NET 8** that provides functionalities for managing German regions and walks. It includes authentication, authorization, and logging mechanisms using **JWT authentication** and **Serilog**.

This API is built as part of the Udemy course: **"Build ASP.NET Core Web API - Scratch To Finish (.NET 8 API)"**.

## Features
- **Regions Management**: Create, Read, Update, and Delete (CRUD) operations.
- **Walks Management**: CRUD operations for walks.
- **User Authentication & Authorization**:
  - User Registration and Login with **ASP.NET Core Identity**.
  - JWT-based authentication.
  - Role-based access control (RBAC) for secured endpoints.
- **Exception Handling Middleware**: Global error handling for better debugging.
- **Logging**: Integrated **Serilog** for logging errors and important application events.
- **Swagger UI**: API documentation and testing using Swagger.

## Technologies Used
- **.NET 8 Web API**
- **Entity Framework Core** (EF Core) for database access
- **SQL Server** for data storage
- **ASP.NET Core Identity** for authentication
- **JWT (JSON Web Token)** for secure API access
- **Serilog** for logging
- **AutoMapper** for object mapping
- **Swagger** for API documentation

## API Endpoints
### Authentication
- **POST /api/auth/register** - Register a new user.
- **POST /api/auth/login** - Authenticate and get a JWT token.

### Regions
- **GET /api/regions** - Get all regions (**Public**).
- **GET /api/regions/{id}** - Get a region by ID (**Public**).
- **POST /api/regions** - Add a new region (**Writer only**).
- **PUT /api/regions/{id}** - Update a region (**Writer only**).
- **DELETE /api/regions/{id}** - Delete a region (**Writer only**).

### Walks
- **GET /api/walks** - Get all walks (**Public**).
- **GET /api/walks/{id}** - Get a walk by ID (**Public**).
- **POST /api/walks** - Add a new walk (**Writer only**).
- **PUT /api/walks/{id}** - Update a walk (**Writer only**).
- **DELETE /api/walks/{id}** - Delete a walk (**Writer only**).

## Middleware
### Exception Handling Middleware
- Handles all unhandled exceptions and returns a custom error response.
- Logs errors using Serilog.
