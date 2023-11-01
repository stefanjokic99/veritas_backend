# veritas_backend
Backend part of the project for my thesis (The importance and role of system architecture in 
process of digital transformation) at the Faculty of Electrical Engineering, University of East Sarajevo. The subject of the application is the system for law enterprises.
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
  * Persistance layer (EF Core, generic implementation of Repository and UnitOfWork pattern)
  * The Application layer (business layer, implemented with CQRS pattern) contains the basic creation of an employee in the system with CRUD operations for a Court Case (the simplest case of write was done without using further business logic, case history,...) (filter and paging were done for reading)
  * The API layer passes tasks to the Application layer using the Mediator Pattern

# Installation
 * Install the Visual Studio and the .NET 7 SDK
 * Clone or download this repository and open the Veritas.sln file in Visual Studio
 * Restore the NuGet packages and run the migrations for the core project
 * Build and run the plugin project from Visual Studio
# Usage
 * The plugin project will expose endpoints for interacting with the core project
 * You can use tools such as Postman or Swagger to test the API requests and responses
 * You can also use the Veritas Frontend project to access the system through a web interface
