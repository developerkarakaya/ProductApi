Product Web Service – .NET 9 Web API
Overview

This project is a Product Web Service developed using .NET 9 Web API, designed with clean architecture principles to ensure scalability, maintainability, and testability.

The system follows the Onion Architecture combined with CQRS (Command Query Responsibility Segregation) and leverages modern enterprise patterns such as MediatR, Redis caching, JWT authentication, FluentValidation, Generic Repository, and Unit of Work.

Architectural Approach
Onion Architecture

The solution is structured according to Onion Architecture, where dependencies always point inward:

Presentation (API)
│
Application
│
Domain
│
Infrastructure

Key Benefits:

Separation of concerns

High testability

Loose coupling

Independent business logic

Layers Description
1. Domain Layer

The core of the application, containing:

Entities (e.g., Product)

Value Objects

Domain rules

Repository interfaces

This layer has no dependency on any other layer.

2. Application Layer

This layer contains:

CQRS commands and queries

MediatR handlers

DTOs

FluentValidation validators

Business use cases

Example responsibilities:

CreateProductCommand

GetProductsQuery

Validation rules for incoming requests

The Application layer depends only on the Domain layer.

3. Infrastructure Layer

Responsible for external concerns, including:

Entity Framework Core

Redis implementation

JWT authentication logic

Repository implementations

Unit of Work implementation

This layer implements interfaces defined in the Domain layer.

4. Presentation Layer (Web API)

The entry point of the application:

HTTP Controllers

Request/response mapping

Authentication & authorization

API versioning and middleware

Controllers are kept thin and delegate all logic to MediatR.

CQRS Pattern

The project applies CQRS to separate:

Commands → Write operations (Create, Update, Delete)

Queries → Read operations (Get, List, Search)

Advantages:

Clear separation of read and write logic

Better scalability

Easier maintenance

Improved performance tuning

MediatR

MediatR acts as an in-process messaging mediator:

Decouples controllers from business logic

Eliminates tight coupling

Enables clean request/handler architecture

Flow:

Controller → MediatR → Handler → Repository

Redis Caching

Redis is used to cache frequently accessed data such as:

Product lists

Product details

Benefits:

Reduced database load

Improved response times

Scalable caching mechanism

Cache invalidation is handled on write operations (CQRS commands).

Authentication & Authorization (JWT)

The API is secured using JWT (JSON Web Token) authentication.

Features:

Stateless authentication

Role-based authorization

Secure token generation and validation

JWT tokens are issued during login and validated on protected endpoints.

FluentValidation

FluentValidation is used for:

Input validation

Business rule enforcement

Clean and readable validation rules

Validation is automatically executed via MediatR pipeline behaviors.

Generic Repository Pattern

A Generic Repository abstracts data access logic:

Reduces code duplication

Provides reusable CRUD operations

Improves maintainability

Example:

IRepository<Product>

Unit of Work

The Unit of Work pattern ensures:

Atomic database operations

Transaction consistency

Centralized commit and rollback control

This is especially important for complex write operations.

Error Handling & Logging

Centralized exception handling middleware

Meaningful HTTP status codes

Structured logging (extensible to Serilog, etc.)

Advantages of the Solution

Clean and maintainable architecture

High scalability

Easy unit and integration testing

Clear separation of responsibilities

Enterprise-grade design patterns

Technologies Used

.NET 9 Web API

Entity Framework Core

MediatR

Redis

FluentValidation

JWT Authentication

SQL Server

Generic Repository & Unit of Work
