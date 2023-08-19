# veritas_backend
Backend part of the project for my thesis. The subject of the application is the system for law enterprises.
The system architecture is shown in the figure.
![ComponentDiagram](https://github.com/stefanjokic99/veritas_backend/assets/77590314/3e87f243-1916-4fad-b07d-ea260df7fc71)

Plugin Architecture is applied to the system. .NET7 WEB API project was used for the core and plugin. Clean Architecture by Robert C. Martin was used as the Architecture of the Plugin.
Currently, the Core project contains:
  * Plugin Manager
  * Basic authentication and authorization using JWT tokens
  * ProxyController
  * ErrorHandlingMiddleware

Currently, the Plugin project contains:
  * Developed a complete Domain for a given problem
  * Persistence layer (EF Core, generic implementation of Repository and UnitOfWork pattern)
  * The Application layer (business layer, implemented with CQRS pattern) contains the basic creation of an employee in the system with CRUD operations for a Court Case (the simplest case of write was done without using further business logic, case history,...) (filter and paging were done for reading)
  * The API layer passes tasks to the Application layer using the Mediator Pattern
