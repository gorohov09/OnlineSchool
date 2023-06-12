#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Presentation/OnlineSchool.API/OnlineSchool.API.csproj", "Presentation/OnlineSchool.API/"]
COPY ["Core/OnlineSchool.App/OnlineSchool.App.csproj", "Core/OnlineSchool.App/"]
COPY ["Core/OnlineSchool.Domain/OnlineSchool.Domain.csproj", "Core/OnlineSchool.Domain/"]
COPY ["Infrastructure/OnlineSchool.Infrastructure/OnlineSchool.Infrastructure.csproj", "Infrastructure/OnlineSchool.Infrastructure/"]
COPY ["Presentation/OnlineSchool.Contracts/OnlineSchool.Contracts.csproj", "Presentation/OnlineSchool.Contracts/"]
RUN dotnet restore "Presentation/OnlineSchool.API/OnlineSchool.API.csproj"
COPY . .
WORKDIR "/src/Presentation/OnlineSchool.API"
RUN dotnet build "OnlineSchool.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OnlineSchool.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnlineSchool.API.dll"]