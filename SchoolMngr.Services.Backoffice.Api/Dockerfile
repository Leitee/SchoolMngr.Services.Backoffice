#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/services/admin/SchoolMngr.Services.BO/SchoolMngr.Services.BO.csproj", "src/services/admin/SchoolMngr.Services.BO/"]
COPY ["src/services/admin/SchoolMngr.BackOffice.DAL/SchoolMngr.BackOffice.DAL.csproj", "src/services/admin/SchoolMngr.BackOffice.DAL/"]
COPY ["src/services/admin/SchoolMngr.BackOffice.Model/SchoolMngr.BackOffice.Model.csproj", "src/services/admin/SchoolMngr.BackOffice.Model/"]
COPY ["src/core/base/Pandora.NetStdLibrary.Base.csproj", "src/core/base/"]
RUN dotnet restore "src/services/admin/SchoolMngr.Services.BO/SchoolMngr.Services.BO.csproj"
COPY . .
WORKDIR "/src/src/services/admin/SchoolMngr.Services.BO"
RUN dotnet build "SchoolMngr.Services.BO.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SchoolMngr.Services.BO.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SchoolMngr.Services.BO.dll"]