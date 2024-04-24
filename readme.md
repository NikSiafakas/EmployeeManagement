# Employee Management Application

This project contains:
* a REST API (ASP.NET Core 6), implementing CRUD funcionality for Employees and the Skills they possess.
* the API connects to a SQL Server (using an Entity Framework Core 6 code-first migration).
* The WebUI for this application is implemented in ReactJS. It consumes the API and it is completely decoupled as an independent project.


## Installation

You will need Visual Studio, an SQL Server and nodeJS.

Use git to clone the repository and open it with Visual Studio.

Modify the "DefaultConnection" in the appsettings.json file to select a server (changing the 'my_server' value to your server name) and Build the solution.

Open the Package Manager Console, change the directory to '\API' and execute 'dotnet ef database update' to create the database. If you do not want sample data in your database, comment out the 'OnModelCreating' method in 'DbContext_SqlServer.cs'.

Open the Command Line, change the directory to '\WebUI' and execute 'npm install react-router-dom'.


## Usage

By running the EmployeeManagementAPI project, you should be able to use the Swagger UI in order to interact with the API.

To run the Web application open the Command Line, change the directory to '\WebUI' and execute 'npm start'.


## License

[MIT](https://choosealicense.com/licenses/mit/)

