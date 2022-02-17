#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["microservices/admin/SchoolMngr.Services.Backoffice/SchoolMngr.Services.Backoffice.csproj", "microservices/admin/SchoolMngr.Services.Backoffice/"]
COPY ["microservices/admin/SchoolMngr.Services.Backoffice.BL/SchoolMngr.Services.Backoffice.BL.csproj", "microservices/admin/SchoolMngr.Services.Backoffice.BL/"]
COPY ["microservices/admin/SchoolMngr.Services.Backoffice.DAL/SchoolMngr.Services.Backoffice.DAL.csproj", "microservices/admin/SchoolMngr.Services.Backoffice.DAL/"]
COPY ["microservices/admin/SchoolMngr.Services.Backoffice.Model/SchoolMngr.Services.Backoffice.Model.csproj", "microservices/admin/SchoolMngr.Services.Backoffice.Model/"]
COPY ["infrastructure/shared/SchoolMngr.Infrastructure.Shared.csproj", "infrastructure/shared/"]
COPY ["../../Codeit.Enterprise.Base/Codeit.Enterprise.Base/Codeit.Enterprise.Base.csproj", "../../Codeit.Enterprise.Base/Codeit.Enterprise.Base/"]
COPY ["../../Codeit.Enterprise.Base/Codeit.Enterprise.Base.Abstractions/Codeit.Enterprise.Base.Abstractions.csproj", "../../Codeit.Enterprise.Base/Codeit.Enterprise.Base.Abstractions/"]
RUN dotnet restore "microservices/admin/SchoolMngr.Services.Backoffice/SchoolMngr.Services.Backoffice.csproj"
COPY . .
WORKDIR "/src/microservices/admin/SchoolMngr.Services.Backoffice"
RUN dotnet build "SchoolMngr.Services.Backoffice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SchoolMngr.Services.Backoffice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SchoolMngr.Services.Backoffice.dll"]