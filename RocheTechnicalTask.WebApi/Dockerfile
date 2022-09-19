#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RocheTechnicalTask.WebApi/RocheTechnicalTask.WebApi.csproj", "RocheTechnicalTask.WebApi/"]
COPY ["RocheTechnicalTask.Application/RocheTechnicalTask.Application.csproj", "RocheTechnicalTask.Application/"]
COPY ["RocheTechnicalTask.Entities/RocheTechnicalTask.Entities.csproj", "RocheTechnicalTask.Entities/"]
COPY ["RocheTechnicalTask.Repository/RocheTechnicalTask.Repository.csproj", "RocheTechnicalTask.Repository/"]
COPY ["RocheTechnicalTask.Abstractions/RocheTechnicalTask.Abstractions.csproj", "RocheTechnicalTask.Abstractions/"]
RUN dotnet restore "RocheTechnicalTask.WebApi/RocheTechnicalTask.WebApi.csproj"
COPY . .
WORKDIR "/src/RocheTechnicalTask.WebApi"
RUN dotnet build "RocheTechnicalTask.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RocheTechnicalTask.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RocheTechnicalTask.WebApi.dll"]