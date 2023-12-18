# Express Delivery

Courier Delivery App.

- [Description](#description)
- [Launch](#launch)
  - [Docker](#docker)
  - [SQLite](#sqlite)
- [Technology Stack](#technology-stack)
  - [Backend](#backend)
    - [Libraries](#libraries)
    - [Database](#database)

## Description

1. Register an application for receipt and delivery of cargo (with the status "New").
2. Display the register of applications.
3. Find the application by the text entered in the field, the search principle is "across all fields".
4. Submit the request for execution (the executors are couriers).
5. Edit the request. At the same time, editing implies:
   - 5.1. Editing data fields is allowed only if the application is in the "New" status
   - 5.2. Transferring the application to the "Submitted for execution" status
   - 5.3. Transferring the application to the "Completed" status
   - 5.4. Transferring the application to the "Canceled" status with a comment on the reason for cancellation
6. Add the cargo to the application.
7. Delete the order.

## Launch

### Docker

In order to run a project using Docker, you need to:

- Check the file in the project `appsettings.json` **"ConnectionStrings"** is equal to:
  `"PostgreSql": "Host=postgres_db;Port=5432;Database=testexpressdelivery;Username=postgres;Password=123"`,
  and **"provider"**: `"PostgreSql"`
- Open the console in this Directory: **Express_Delivery\ExpressDelivery.Backend**.
- Type and run the command: `docker-compose up`

### SQLite

- Select the project to be launched: **"ExpressDelivery.WebApi"**
- Check the file in the project `appsettings.json` **"ConnectionStrings"** is equal to: `"Sqlite": "Data Source=ExpressDelivery.db"`, and **"provider"**: `"Sqlite"`

## Technology Stack

### Backend

C#, 6.0 Core, EF Core, Docker, Swagger.

#### Libraries

Serilog, AutoMapper, FluentValidation

#### Database

SQLite, PostgreSQL.
