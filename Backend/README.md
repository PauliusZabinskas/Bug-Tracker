# TodoTask API

# password: $sa_password = "Bug_Issue_DB_SQL"
# to stop docker: docker stop mssql
# to check if docker is running: docker ps

## Starting SQL Server
```powershell
$sa_password = "Bug_Issue_DB_SQL"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -p 1433:1433 -v sqlvolume:/var/opt/mssql -d --rm --name mssql mcr.microsoft.com/mssql/server:2022-latest
```

# to check user secrest: 
```powerhell
dotnet user-secrets init

dotnet user-secrets list
```

# to add Entity Frame Work: 
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

## Setting the connection string to secret manager
```powershell
$sa_password = "Bug_Issue_DB_SQL"
dotnet user-secrets set "ConnectionStrings:TodoTaskContext" "Server=localhost; Database=TodoTask; User Id=sa; Password=$sa_password; TrustServerCertificate=True"

```

## to add dotnet Auth pakage:
```powershell
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
```



