# Applicant Management System

## Description

The Applicant Management System is a web application designed to manage applicant information. It allows users to create, read, update, and delete applicant records. The application is built using ASP.NET Core and Entity Framework Core.

## Features

- Add new applicants
- View a list of all applicants
- Update applicant details
- Delete applicants
- Validate applicant information

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Getting Started

### Clone the Repository

https://github.com/OmarYassin22/Task.git


### Setup the Database

1. Open `appsettings.json` and update the connection string to point to your SQL Server instance.

"ConnectionStrings": { "AppDbContext": "Server=your_server;Database=your_database;User Id=your_user;Password=your_password;" }


### Build and Run the Application

1. Open the solution in Visual Studio.
2. Build the solution by clicking on `Build > Build Solution`.
3. Run the application by clicking on `Debug > Start Debugging` or pressing `F5`.

### Using the Application

1. Open your web browser and navigate to  `https://localhost:7152` or `http://localhost:5054)`.
2. You will see the home page of the Applicant Management System.
3. Use the navigation menu to add, view, update, or delete applicants.

### Use Postman in Test
1. import `Postmant collection.json` from the API app
2. Modify baseUrl variable in `Applicant Management System`
3. Select API as the startup project
4. Then Start Test

## Project Structure

- `Controllers`: Contains the MVC controllers.
- `Models`: Contains the data models and DTOs.
- `Views`: Contains the Razor views.
- `Data`: Contains the database context and migration files.
- `Services`: Contains the business logic and service classes.

## Contributing

If you would like to contribute to this project, please fork the repository and submit a pull request.



# Applicant Management System

## Description

The Applicant Management System is a web application designed to manage applicant information. It allows users to create, read, update, and delete applicant records. The application is built using ASP.NET Core and Entity Framework Core.

## Features

- Add new applicants
- View a list of all applicants
- Update applicant details
- Delete applicants
- Validate applicant information

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Getting Started

### Clone the Repository

https://github.com/OmarYassin22/Task.git


### Setup the Database

1. Open `appsettings.json` and update the connection string to point to your SQL Server instance.

"ConnectionStrings": { "AppDbContext": "Server=your_server;Database=your_database;User Id=your_user;Password=your_password;" }


### Build and Run the Application

1. Open the solution in Visual Studio.
2. Build the solution by clicking on `Build > Build Solution`.
3. Run the application by clicking on `Debug > Start Debugging` or pressing `F5`.

### Using the Application

1. Open your web browser and navigate to `https://localhost:5001`.
2. You will see the home page of the Applicant Management System.
3. Use the navigation menu to add, view, update, or delete applicants.

## Project Structure

- `Controllers`: Contains the MVC controllers.
- `Models`: Contains the data models and DTOs.
- `Views`: Contains the Razor views.
- `Data`: Contains the database context and migration files.
- `Services`: Contains the business logic and service classes.

## Contributing

If you would like to contribute to this project, please fork the repository and submit a pull request.



