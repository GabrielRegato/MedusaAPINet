# MEDUSA .NET API

The Medusa.NET API is a sample source code that demonstrates a comprehensive API service, featuring a range of endpoints including Employees, Departments, Salaries, and Payment Methods. Each endpoint is equipped with full CRUD (Create, Read, Update, Delete) functionality, leveraging a database built on SQL Server.

## Installation

To get started, download the project and follow these steps to build and run the application:

1.- Open a terminal or command prompt in the project directory.
2.- Run the command:

```bash
dotnet build
```

To build the application.

Alternatively, you can open the project in Visual Studio and press F5 or click the "Run" button to build and run the application in debug mode.

With the application built, you can now start it by running the following command:

```bash
dotnet run
```

This will launch the application and make it available for use. You can then access the API endpoints using a tool like Postman or cURL.

# API Endpoints

The following API endpoints are available for use:

## 1. Get All Employees

### Endpoint

`GET /api/Employee`

### Description

Retrieves a list of all employees.

### Request

```bash
curl -X GET \
  http://localhost:5133/api/Employee \
  -H 'Content-Type: application/json'
```

### Response

```json
[
  {
    "employee_id": 1,
    "first_Name": "John",
    "last_Name": "Doe",
    "start_Date": "2024-05-05T00:00:00",
    "birthday": "1990-02-12T00:00:00",
    "department_id": 1
  },
  {
    "employee_id": 2,
    "first_Name": "Jane",
    "last_Name": "Smith",
    "start_Date": "2019-06-01T00:00:00",
    "birthday": "1992-08-25T00:00:00",
    "department_id": 2
  }
]
```

## 2. Get Employee by {id}

### Endpoint

`GET /api/Employee/{id}`

### Description

Retrieve the information of a specific Employee.

### Request

```bash
curl -X GET \
  http://localhost:5133/api/Employee/11 \
  -H 'Content-Type: application/json'
```

### Response

```json
{
  "employee_id": 1,
  "first_Name": "John",
  "last_Name": "Doe",
  "start_Date": "2024-05-05T00:00:00",
  "birthday": "1990-02-12T00:00:00",
  "department_id": 1
}
```

## 3. Create New Employee

### Endpoint

`POST /api/Employee`

### Description

Create a new employee.

### Request

```bash
curl -X POST \
  http://localhost:5133/api/Employee/ \
  -H 'Content-Type: application/json' \
  -d '{"first_Name": "Juan", "last_Name": "Escutia", "start_Date": "2022-01-01T00:00:00", "birthday": "1990-01-01T00:00:00", "department_id": 6}'
```

### Response

```json
{
  "employee_id": 14,
  "first_Name": "Juan",
  "last_Name": "Escutia",
  "start_Date": "2022-01-01T00:00:00",
  "birthday": "1990-01-01T00:00:00",
  "department_id": 6
}
```

## 4. Update Employee {id}

### Endpoint

`PUT /api/Employee/{id}`

### Description

Update an actual employee.

### Request

```bash
curl -X PUT \
  http://localhost:5133/api/Employee/12 \
  -H 'Content-Type: application/json' \
  -d '{"first_Name": "Juanito", "last_Name": "Escutia", "start_Date": "2022-01-01T00:00:00", "birthday": "1990-01-01T00:00:00", "department_id": 3}'
```

### Response

```json
We are going to receive a Status 204 with No Content.
```

## 5. Delete Employee {id}

### Endpoint

`DELETE /api/Employee/{id}`

### Description

Delete an actual employee.

### Request

```bash
curl -X DELETE \
  http://localhost:5133/api/Employee/11
```

### Response

```json
We are going to receive a Status 204 with
```

## 6. Other modules: Department, Salary, PaymentMethod

### Urls

`Department: /api/Department`
`Salary: /api/Salary`
`Payment Methods: /api/PaymentMethod`

### Description

We have similar endpoints for the Department, Salary, and Payment Method modules, which mirror the Employees endpoints. The main difference lies in the endpoint name and the structure of the data being sent or received.

### Structure of Data

```json
Department:

{
  "department_description": "Example"
}

Salary:

{
  "employee_id": 18,
  "monthly_salary": 9550.56,
  "payment_method_id": 2
}

PaymentMethod:

{
    "payment_method_name": "Cash"
}

```

# Database Table Setup

The following SQL queries are designed to create the necessary tables for our project, providing the foundation for our database structure.

### Employees Table

```sql
CREATE TABLE employees (
employee_id INT IDENTITY(1,1) PRIMARY KEY,
first_Name NVARCHAR(50) NOT NULL,
last_Name NVARCHAR(50) NOT NULL,
start_Date DATE NOT NULL,
birthday DATE NOT NULL,
department_id INT
);
```

### Payment Methods Table

```sql
CREATE TABLE payment_methods (
payment_method_id INT IDENTITY(1,1) PRIMARY KEY,
payment_method_name NVARCHAR(50) NOT NULL
);
```

### Salaries Table

```sql
CREATE TABLE salaries (
salary_id INT IDENTITY(1,1) PRIMARY KEY,
employee_id INT NOT NULL,
monthly_salary DECIMAL(10, 2) NOT NULL,
payment_method_id INT NOT NULL,
FOREIGN KEY (employee_id) REFERENCES employee(employee_id),
FOREIGN KEY (payment_method_id) REFERENCES payment_methods(payment_method_id)
);
```

### Departments Table

```sql
CREATE TABLE [dbo].[departments] (
    department_id INT IDENTITY(1,1) PRIMARY KEY,
    department_description NVARCHAR(100) NOT NULL
);
```

## Disclaimer

This repository is provided "as is" and without warranty of any kind. Use at your own risk. While we hope this repository helps you get started with.NET APIs, you are responsible for modifying and adapting the code to suit your specific needs. You may improve or change the endpoints as necessary, but please be aware that we do not guarantee the accuracy, completeness, or reliability of the code.

Medusa .NET API - Gabriel A.R.
