COMMUNITY LIBRARY MANAGEMENT API

- A RESTful Web API for managing a community library system.
  The API allows the management of books, library members, and book loans.

PROJECT OVERVIEW

- The Community Library Management API is built using ASP.NET Core Web API.
  It follows a layered structure to separate controllers, services, repositories,
  models, and data access.

The system provides API endpoints for:

- Managing books
- Managing library members
- Managing book loans
- Returning borrowed books
- Connecting to a SQL Server database

TEAM MEMBERS AND CONTRIBUTIONS

| Members | Assigned Feature |
|---|---|
| Jacob | Books |
| JB | Members |
| Saydee | Loans |

Jacob — Books

Responsible for the Books feature, including:

- Book model
- Book DTO
- Book repository
- Book service
- Books controller
- Book CRUD operations
- Returning books

JB — Members

Responsible for the Members feature, including:

- Member model
- Member DTO
- Member repository
- Member service
- Members controller
- Member CRUD operations
- Loan repository

### Saydee — Loans

Responsible for the Loans feature, including:

- Loan model
- Loan DTO
- Loan service
- Loans controller
- Creating loans
- Retrieving loans
- Deleting loans

## Technologies Used

- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- SQL Server Express
- Swagger / OpenAPI
- Git
- GitHub
- Visual Studio

## Project Structure

```text
CommunityLibraryManagementAPI/
│
├── Controllers/
│   ├── BooksController.cs
│   ├── MembersController.cs
│   └── LoansController.cs
│
├── Models/
│   ├── Domain/
│   │   ├── Book.cs
│   │   ├── Member.cs
│   │   └── Loan.cs
│   │
│   └── Dto/
│       ├── BookDto.cs
│       ├── MemberDto.cs
│       └── LoanDto.cs
│
├── Repositories/
│   ├── IBookRepository.cs
│   ├── BookRepository.cs
│   ├── IMemberRepository.cs
│   ├── MemberRepository.cs
│   ├── ILoanRepository.cs
│   └── LoanRepository.cs
│
├── Services/
│   ├── IBookService.cs
│   ├── BookService.cs
│   ├── IMemberService.cs
│   ├── MemberService.cs
│   ├── ILoanService.cs
│   └── LoanService.cs
│
├── Properties/
│   └── launchSettings.json
│
├── appsettings.json
├── Program.cs
└── CommunityLibraryManagementAPI.csproj


PROJECT OBJECTIVES
The main objectives of this project are:

- To develop a functional RESTful Web API for a community library.
- To implement CRUD operations using ASP.NET Core.
- To use Entity Framework Core for database operations.
- To manage relationships between books, members, and loans.
- To apply layered architecture using Controllers, Services, and Repositories.
- To practice collaborative software development using Git and GitHub. 
```


CONCLUSION

- The Community Library Management System demonstrates how a RESTful Web API can be used to manage common library operations.
  Through ASP.NET Core, Entity Framework Core, and SQL Server, the system provides an organized way to manage books, members,
  and borrowing transactions.

- The use of layered architecture also helps separate API requests, business logic, and database operations,
  making the application easier to maintain and improve.

GROUP MEMBERS

Saydee Alesana Salvador
Jacob Marquiz Cagang
JohnBenedict Estimada
