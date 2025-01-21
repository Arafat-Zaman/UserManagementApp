

**README.md** file for your project, covering both the backend (`UserManagementApp.Server`) and frontend (`UserManagementApp.Client`):

---

# **User Management Application**

A web-based application to manage users' data with support for multiple data sources (SQL and JSON). The application includes a backend built using ASP.NET Core and a frontend built using Angular.

---

## **Table of Contents**
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Backend Setup](#backend-setup)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Environment Configuration](#environment-configuration)
  - [Database Setup](#database-setup)
  - [Running the Backend](#running-the-backend)
- [Frontend Setup](#frontend-setup)
  - [Prerequisites](#prerequisites-1)
  - [Installation](#installation-1)
  - [Running the Frontend](#running-the-frontend)
- [Usage](#usage)
- [API Documentation](#api-documentation)
- [Directory Structure](#directory-structure)
- [Production Deployment](#production-deployment)

---

## **Features**
- Manage user data (CRUD operations).
- Multiple data source support (SQL Database and JSON file).
- Single Page Application (SPA) built with Angular.
- Responsive user interface.
- Dynamic switching of data sources.
- REST API with clean architecture.

---

## **Technologies Used**
### **Backend (UserManagementApp.Server)**
- ASP.NET Core
- Entity Framework Core
- SQL Server
- JSON Data Provider
- Swagger (API Documentation)
- Dependency Injection
- LINQ

### **Frontend (UserManagementApp.Client)**
- Angular
- TypeScript
- HTML5/CSS3
- Bootstrap

---

## **Backend Setup**

### **Prerequisites**
- [.NET SDK](https://dotnet.microsoft.com/download) (version 6 or later)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio](https://visualstudio.microsoft.com/) or any code editor.

---

### **Installation**
1. Clone the repository:
   ```bash
   git clone https://github.com/your-repo/user-management-app.git
   cd user-management-app/UserManagementApp.Server
   ```

2. Restore NuGet packages:
   ```bash
   dotnet restore
   ```

---

### **Environment Configuration**
Update the `appsettings.json` file to configure the database connection and data source:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=UserDB;Trusted_Connection=True;"
  },
  "DataSource": "SQL" // Use "JSON" for JSON-based data source
}
```

---

### **Database Setup**
1. Create the database using EF Core migrations:
   ```bash
   dotnet ef database update
   ```

2. Seed the database with initial data 


---

{
 "id”: 1,
 "firstName”: "Shibli",
 "lastName”: "Arafat",
 "active”: true,
 "company”: "SoftwarePeople",
 "sex": "M", 
 "contact”:
 {
 "id": 1,
 "phone": "+41023658",
 "address": "Banani",
 "city": "Dhaka",
 "country": "Bangladesh"
 },
 "role": 
 {
 "id": 5,
 "name": "manager"
 }
}




### **Running the Backend**
1. Run the application:
   ```bash
   dotnet run
   ```

2. The API will be accessible at:
   - **Swagger Documentation:** `https://localhost:7038/swagger`
   - **Base URL:** `https://localhost:7038/api`

---

## **Frontend Setup**

### **Prerequisites**
- [Node.js](https://nodejs.org/) (version 14 or later)
- [Angular CLI](https://angular.io/cli)

---

### **Installation**
1. Navigate to the frontend directory:
   ```bash
   cd user-management-app/UserManagementApp.Client
   ```

2. Install dependencies:
   ```bash
   npm install
   ```

---

### **Running the Frontend**
1. Start the Angular development server:
   ```bash
   ng serve
   ```

2. Open the application in your browser:
   - **URL:** `http://localhost:4200`

---

## **Usage**
1. Navigate to the application in your browser (`http://localhost:4200`).
2. Use the dropdown in the header to select the data source (`SQL` or `JSON`).
3. Perform CRUD operations:
   - **View All Users:** Displays a paginated list of users.
   - **View Details:** Navigate to a user's details page.
   - **Update User:** Edit an existing user's details.
   - **Delete User:** Remove a user from the selected data source.

---

## **API Documentation**
The API documentation is available via Swagger:
- URL: `https://localhost:7038/swagger`

**Endpoints:**
- **GET** `/api/users`: Retrieve all users.
- **GET** `/api/users/{id}`: Retrieve a user by ID.
- **POST** `/api/users`: Add a new user.
- **PUT** `/api/users`: Update an existing user.
- **DELETE** `/api/users/{id}`: Delete a user by ID.

---

## **Directory Structure**
### **Backend**
```
UserManagementAPI/
├── Controllers/
│   ├── UsersController.cs            # API Endpoints for Users
│   ├── DataSourceController.cs            # API Endpoints for Datasource
├── Data/
│   ├── SQLContext.cs                 # SQL Database context
│   ├── JSONDataProvider.cs           # JSON or NoSQL data provider
│   ├── IDataProvider.cs              # Abstraction for data providers
│   ├── Repository/
│       ├── IUserRepository.cs        # Interface for repository
│       ├── UserRepository.cs         # Implementation of repository
├── Models/
│   ├── User.cs                       # User model
│   ├── Contact.cs                    # Contact model
│   ├── Role.cs                       # Role model
├── Services/
│   ├── IUserService.cs               # Interface for user service
│   ├── UserService.cs                # Implementation of user service
├── Migrations/
│   ├── <AutoGeneratedFiles>          # Migration files for database
├── appsettings.json                  # Configuration (switch data source)
├── Program.cs                        # Entry point (bootstrap), Middleware and services configuration
├── README.md                         # Instructions to run the project
└── Tests/
    ├── IntegrationTests/
    │   ├── UserIntegrationTests.cs   # Integration tests for APIs
    ├── UnitTests/
        ├── UserServiceTests.cs       # Unit tests for service layer

```

### **Frontend**
```
UserManagementFrontend/
├── src/
│   ├── app/
│   │   ├── components/
│   │   │   ├── header/
│   │   │   │   ├── header.component.ts      # Header component
│   │   │   │   ├── header.component.html    # Template for header
│   │   │   │   ├── header.component.css     # Styles for header
│   │   │   ├── user-list/
│   │   │   │   ├── user-list.component.ts   # List component logic
│   │   │   │   ├── user-list.component.html # List component template
│   │   │   │   ├── user-list.component.css  # List component styles
│   │   │   ├── user-details/
│   │   │   │   ├── user-details.component.ts # Details component logic
│   │   │   │   ├── user-details.component.html # Details component template
│   │   │   │   ├── user-details.component.css # Details component styles
│   ├── services/
│   │   ├── user.service.ts                   # Service to consume API
│   ├── models/
│   │   ├── user.model.ts                     # User interface/model
│   ├── environments/
│   │   ├── environment.ts                   # Dev environment
│   │   ├── environment.prod.ts              # Prod environment
│   ├── assets/
│   │   ├── styles.css                       # Global styles
│   ├── app.module.ts                        # Main app module
│   ├── app.component.ts                     # Root component logic
│   ├── app.component.html                   # Root template
│   ├── app-routing.module.ts                # Routing configuration
├── angular.json                              # Angular CLI configuration
├── package.json                              # Project dependencies
├── README.md                                 # Instructions to run the project



```

---

## **Troubleshooting**
- **CORS Issues:**
  - Ensure CORS is configured in `Program.cs` for the backend:
    ```csharp
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAngularApp", policy =>
        {
            policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
        });
    });
    ```

- **Database Connection Issues:**
  - Verify the connection string in `appsettings.json`.

---


## **Deployment**
1. Deployment of UserManagementApp.Client

1.1 Prerequisites
Install Node.js (version 18.x or higher).
Install Angular CLI globally

npm install -g @angular/cli
A production-ready web server (e.g., Nginx, Apache, or IIS) is required.


1.2 Steps to Build and Deploy
1.Navigate to the Client Directory:
cd UserManagementApp/ClientApp

2.Install Dependencies:
npm install

3.Build for Production:
Run the following command to generate production-optimized static files:
ng build --configuration=production
This will create a dist/ directory containing the compiled static files.

4.Deploy the Static Files:
Copy the contents of the dist/ directory to your web server's root directory.
For IIS, deploy to the appropriate site folder.

5.Configure the Web Server:
Ensure that the web server routes all requests to the index.html file to support Angular's client-side routing.




2. Deployment of UserManagementApp.Server

2.1 Prerequisites
Install the .NET SDK (version 7 or 8).
A production-ready application server, such as:
Kestrel (default for .NET apps).
IIS (Windows environments).
A database server (e.g., SQL Server).

2.2 Steps to Deploy
Navigate to the Server Directory:
cd UserManagementApp/Server

3.Publish the Application:
Run the following command to publish the application:
dotnet publish -c Release -o ./publish
This creates a publish/ directory with the compiled application files.

4.Configure the Database:
Ensure the production database is set up with the correct schema.
Apply migrations

5.Set Environment Variables:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your-server;Database=UserDB;User Id=your-user;Password=your-password;Encrypt=False;"
  },
  "DataSource": "SQL",
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}


6.Deploy to Server:
Copy the contents of the publish/ directory to your server.


7.Run the Application:
Using Kestrel:
dotnet UserManagementApp.Server.dll

Using IIS:
Add the application to IIS Manager as a new site.
Point it to the publish/ directory.

