Library Management System

A console-based library management system built in C#, using Entity Framework Core with SQLite for data persistence. It handles book borrowing and returning, with validation logic to enforce basic library rules.

Features
Add, view, and manage books and members
Borrow and return books with validation (e.g. availability checks, member limits)
Data persisted locally using SQLite via Entity Framework Core
Simple, extendable console interface
Tech Stack
Language: C#
ORM: Entity Framework Core
Database: SQLite
Project Structure
Book.cs — Book entity model
Member.cs — Member entity model
LibraryContext.cs — EF Core database context
Migrations/ — EF Core database migrations
Program.cs — Application entry point
Getting Started
Prerequisites
.NET SDK installed
Run locally
bash
# Clone the repository
git clone https://github.com/nabin733/library-management-system.git
cd library-management-system

# Restore dependencies
dotnet restore

# Apply database migrations
dotnet ef database update

# Run the application
dotnet run
What I learned

Building this project helped me get hands-on with Entity Framework Core migrations, structuring a relational schema around real-world borrow/return rules, and thinking through validation logic before it hits the database.

Author

Nabin Gnawali — GitHub

Content
