#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ENV ASPNETCORE_ENVIRONMENT=Development 
WORKDIR /src
COPY ["FluentApiModelMappingToDatabase/FluentApiModelMappingToDatabase.csproj", "FluentApiModelMappingToDatabase/"]
COPY ["DAL/DAL.csproj", "DAL/"]
RUN dotnet restore "FluentApiModelMappingToDatabase/FluentApiModelMappingToDatabase.csproj"
COPY . .
WORKDIR "/src/FluentApiModelMappingToDatabase"
RUN dotnet build "FluentApiModelMappingToDatabase.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FluentApiModelMappingToDatabase.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FluentApiModelMappingToDatabase.dll", "--environment=Development"]