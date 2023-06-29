# TodoTask API

# password = Bug_Issue_DB_SQL
# to stop docker: docker stop mssql
# to check if docker is running: docker ps

## Starting SQL Server
```powershell
$sa_password = "[SA PASSWORD HERE]"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -p 1433:1433 -v sqlvolume:/var/opt/mssql -d --rm --name mssql mcr.microsoft.com/mssql/server:2022-latest
```
## Setting the connection string to secret manager
```powershell
$sa_password = "[SA PASSWORD HERE]"
dotnet user-secrets set "ConnectionStrings:TodoTaskContext" "Server=localhost; Database=TodoTask; User Id=sa; Password=$sa_password; TrustServerCertificate=True"

```
# to check user secrest: dotnet user-secrets list

# to add Entity Frame Wor: 
```powerhell
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.8
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design

```

# to add initial migration 
```powershell
dotnet ef migrations add InitialCreate --output-dir Data\Migrations
```

# time to Applying a database migration
```powershell
dotnet ef database update
```
