# UsermanagementappClient

This project was generated using [Angular CLI](https://github.com/angular/angular-cli) version 19.1.2.

## Development server

To start a local development server, run:

```bash
ng serve
```

Once the server is running, open your browser and navigate to `http://localhost:4200/`. The application will automatically reload whenever you modify any of the source files.

## Code scaffolding

Angular CLI includes powerful code scaffolding tools. To generate a new component, run:

```bash
ng generate component component-name
```

For a complete list of available schematics (such as `components`, `directives`, or `pipes`), run:

```bash
ng generate --help
```

## Building

To build the project run:

```bash
ng build
```

This will compile your project and store the build artifacts in the `dist/` directory. By default, the production build optimizes your application for performance and speed.

## Running unit tests

To execute unit tests with the [Karma](https://karma-runner.github.io) test runner, use the following command:

```bash
ng test
```

## Running end-to-end tests

For end-to-end (e2e) testing, run:

```bash
ng e2e
```

Angular CLI does not come with an end-to-end testing framework by default. You can choose one that suits your needs.

## Additional Resources

For more information on using the Angular CLI, including detailed command references, visit the [Angular CLI Overview and Command Reference](https://angular.dev/tools/cli) page.



////////////



Here is a comprehensive **README.md** file for your project, covering both the backend (`UserManagementApp.Server`) and frontend (`UserManagementApp.Client`):

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

---

## **Features**
- Manage user data (CRUD operations).
- Multiple data source support (SQL Database and JSON file).
- Single Page Application (SPA) built with Angular.
- Pagination for large datasets.
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

2. Seed the database with initial data (if applicable).

---

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
   - **Add User:** Add a new user to the selected data source.
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
UserManagementApp.Server/
├── Controllers/
│   └── UsersController.cs         # API Endpoints
├── Data/
│   ├── SQLContext.cs              # SQL Database Context
│   ├── JSONDataProvider.cs        # JSON Data Provider
│   ├── Repository/
│       ├── IUserRepository.cs     # Repository Interface
│       ├── UserRepository.cs      # Repository Implementation
├── Models/
│   └── User.cs                    # User Model
├── Services/
│   ├── IUserService.cs            # Service Interface
│   ├── UserService.cs             # Service Implementation
├── Program.cs                     # Application Bootstrap
├── appsettings.json               # Configuration File
```

### **Frontend**
```
UserManagementApp.Client/
├── src/
│   ├── app/
│   │   ├── components/
│   │   │   ├── header/
│   │   │   ├── user-list/
│   │   │   ├── user-details/
│   │   ├── services/
│   │   ├── models/
│   ├── environments/
│   │   ├── environment.ts         # Development Environment
│   │   ├── environment.prod.ts    # Production Environment
├── angular.json                   # Angular Configuration
├── package.json                   # Project Dependencies
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

## **License**
This project is licensed under the MIT License.

---

Let me know if you need further customization or additions!
