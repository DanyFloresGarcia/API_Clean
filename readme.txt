SERVIDOR: DESKTOP-TDTGQLB\SQLEXPRESS

USER: DESKTOP-TDTGQLB\W10

INSTALAR dotnet7


CREAR UNA SOLUCION
dotnet new sln -o #nombre

CREAR BIBLIOTECA DE CLASES
dotnet new classlib -o Domain -f net7.0

CREAR API WEB
dotnet new webapi -o Web.API -f net7.0

AGREGAR REFERENCIAS ENTRE CAPAS
dotnet add Application/Application.csproj reference Domain/Domain.csproj
dotnet add Infrastructure/Infrastructure.csproj reference Domain/Domain.csproj

dotnet add Infrastructure/Infrastructure.csproj reference Application/Application.csproj

dotnet add WebAPI/WebAPI.csproj reference Application/Application.csproj
dotnet add WebAPI/WebAPI.csproj reference Infrastructure/Infrastructure.csproj

AGREGAR REFERENCIAS A LA SOLUCION
dotnet sln add Web.API/Web.API.csproj
dotnet sln add Application/Application.csproj
dotnet sln add Infrastructure/Infrastructure.csproj
dotnet sln add Domain/Domain.csproj


PARA COMPILAR
DOTNET BUILD

PARA LEVANTAR 
dotnet run -p Web.API  puerto  http://localhost:5134
dotnet run -p Web.APIGateway http://localhost:5250

PARA MIGRAR
dotnet ef migrations add InitialMigration -p Infrastructure -s Web.API -o Persistence/Migrations

PARA ACTUALIZAR BD
dotnet ef database update -p Infrastructure -s Web.API