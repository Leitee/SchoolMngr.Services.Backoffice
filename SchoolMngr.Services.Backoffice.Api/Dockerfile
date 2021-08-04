#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["microservices/admin/SchoolMngr.Services.Backoffice.Api/SchoolMngr.Services.Backoffice.csproj", "microservices/admin/SchoolMngr.Services.Backoffice.Api/"]
COPY ["microservices/admin/SchoolMngr.Services.Backoffice.BL/SchoolMngr.Services.Backoffice.BL.csproj", "microservices/admin/SchoolMngr.Services.Backoffice.BL/"]
COPY ["microservices/admin/SchoolMngr.Services.Backoffice.DAL/SchoolMngr.Services.Backoffice.DAL.csproj", "microservices/admin/SchoolMngr.Services.Backoffice.DAL/"]
COPY ["microservices/admin/SchoolMngr.Services.Backoffice.Model/SchoolMngr.Services.Backoffice.Model.csproj", "microservices/admin/SchoolMngr.Services.Backoffice.Model/"]
COPY ["infrastructure/shared/SchoolMngr.Infrastructure.Shared.csproj", "infrastructure/shared/"]
COPY ["../../Codeit.NetStdLibrary.Base/Codeit.NetStdLibrary.Base/Codeit.NetStdLibrary.Base.csproj", "../../Codeit.NetStdLibrary.Base/Codeit.NetStdLibrary.Base/"]
COPY ["../../Codeit.NetStdLibrary.Base/Codeit.NetStdLibrary.Base.Abstractions/Codeit.NetStdLibrary.Base.Abstractions.csproj", "../../Codeit.NetStdLibrary.Base/Codeit.NetStdLibrary.Base.Abstractions/"]
RUN dotnet restore "microservices/admin/SchoolMngr.Services.Backoffice.Api/SchoolMngr.Services.Backoffice.csproj"
COPY . .
WORKDIR "/src/microservices/admin/SchoolMngr.Services.Backoffice.Api"
RUN dotnet build "SchoolMngr.Services.Backoffice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SchoolMngr.Services.Backoffice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SchoolMngr.Services.BO.dll"]