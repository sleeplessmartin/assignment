# Assignment

# Assignment API

## Endpoints Overview

### 1. Check-in Endpoints
- **GET /api/checkin/{checkin_id}**
  - Retrieves a check-in by its ID.
  - Usage: `GET /api/checkin/1`
- **GET /api/checkin?filter={filter}**
  - Retrieves a list of check-ins filtered by a string (status/message/user_id) or a date (created_timestamp).
  - Usage: `GET /api/checkin?filter=happy` or `GET /api/checkin?filter=2025-06-23`
- **POST /api/checkin**
  - Creates a new check-in.
  - Usage: Send a JSON body with required fields.
- **PUT /api/checkin/{checkin_id}**
  - Updates an existing check-in by ID.
  - Usage: Send a JSON body with updated fields.

### 2. User Endpoints
- **POST /api/user**
  - Retrieves user details by user ID.
  - This was set to a POST because this will simulate a user login, which normally should be checked against an identity server
  - Note that user id's are set as strings for simplicity. Please go to `Shortcuts taken` section.
  - Usage: `POST /api/user` and send a JSON body with the `user_id` and `password`.

## Running Migrations on a Fresh Machine

1. **Install .NET SDK**
   - Download and install the latest .NET SDK from https://dotnet.microsoft.com/download

2. **Install Entity Framework Core Tools**
   - Open a terminal and run:
     ```sh
     dotnet tool install --global dotnet-ef
     ```

3. **Restore NuGet Packages**
   - In the project root, run:
     ```sh
     dotnet restore
     ```

4. **Add a Migration (if needed)**
   - If you have model changes and need to add a migration:
     ```sh
     dotnet ef migrations add <MigrationName> --project Infrastructure/Infrastructure.csproj --startup-project API/API.csproj
     ```

5. **Update the Database**
   - To apply migrations and update the database:
     ```sh
     dotnet ef database update --project Infrastructure/Infrastructure.csproj --startup-project API/API.csproj
     ```

   - This uses the connection string in `API/appsettings.json`.

6. **Troubleshooting**
   - Ensure PostgreSQL is running and accessible with the credentials in `appsettings.json`.
   - If you get file not found errors for `users.json`, ensure it is copied to the output directory or adjust the path in code.

## Shortcuts Taken

> Any 'NOTE to Oleg' comments in the code are collected here:

- In a real application, user id's (`user_id`, `created_by_id`, `updated_by_id`) would likely be a foreign key to a user table and should be a bigint/long datatype instead of varchar or string. For purposes of simplicity, I used string as id's.
- For the `GetCheckinsListByFilter` service was simplified intentionally. I would normally use a stored procedures for queries involving joins and where clauses a little more complex than straight ID searchers.

---

For further details, see inline code comments and the `Application/DependencyInjection.cs` for service registration logic.