# PROGPOE
# RaceDay Part B — continuation package

## Important scope disclosure
The supplied ZIP contained the MVC starter only. It did not contain the original Part 2 API or its endpoint contract. To let development continue, this package adds a **new companion API scaffold** in `RaceDay.Api`. It is not a reconstruction of your lecturer's original Part 2 API. Confirm its contract with your lecturer before submission.

## Projects
- `RaceDayMVC_Rebuilt`: supplied MVC project, retained as the UI baseline.
- `RaceDay.Api`: companion REST API scaffold with event, category, enrolment, results and upload endpoints.
- `docker-compose.yml`: SQL Server + API + MVC containers.
- `.github/workflows/build.yml`: CI build for both .NET projects.

## Critical remaining integration work
The existing MVC controllers still use `ApplicationDbContext` and ASP.NET Identity directly. This is visible in `RaceDayMVC_Rebuilt/Program.cs` and its controllers. **Therefore the package is not yet compliant with the requirement that MVC must consume the API for all data operations.** Before final submission, replace MVC database calls with typed `HttpClient` API calls, move authentication to API-issued tokens/session storage, and remove MVC EF/Identity database registration. The supplied API auth endpoint is also not implemented yet: register/login and role assignment must be completed and tested before use. The current API upload endpoints require authenticated claims and the Azure connection string.

## Run
Install Docker Desktop and start Docker. From this directory:
```bash
docker compose up --build
```
- MVC: http://localhost:8080
- API health: http://localhost:8081/health
- Swagger (Development): http://localhost:8081/swagger

Set `AZURE_BLOB_CONNECTION_STRING` in your environment before testing uploads. Replace all development secrets/passwords before deployment. Do not expose SQL Server publicly.

## Local build
```bash
dotnet build RaceDay.Api/RaceDay.Api.csproj
dotnet build RaceDayMVC_Rebuilt/RaceDayMVC.csproj
```
The container/API project needs its first EF migration and database update before database-backed routes work:
```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate --project RaceDay.Api
dotnet ef database update --project RaceDay.Api
```
The API scaffold's database schema is separate from the MVC starter schema.

## GitHub
Create a branch named `Part-B`, commit the work in small logical units, and push:
```bash
git checkout -b Part-B
git add .
git commit -m "Add Part B API project scaffold"
git push -u origin Part-B
```
CI runs on pushes to `main`, `Part-B`, and `part-b`.
