#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Source/CommandsService.Entry.WebApi/CommandsService.Entry.WebApi.csproj", "Source/CommandsService.Entry.WebApi/"]
COPY ["Source/CommandsService.Application/CommandsService.Application.csproj", "Source/CommandsService.Application/"]
COPY ["Source/CommandsService.Core/CommandsService.Core.csproj", "Source/CommandsService.Core/"]
COPY ["Source/CommandsService.Persistence.Interfaces/CommandsService.Persistence.Interfaces.csproj", "Source/CommandsService.Persistence.Interfaces/"]
COPY ["Source/CommandsService.Entry/CommandsService.Entry.csproj", "Source/CommandsService.Entry/"]
COPY ["Source/CommandsService.Infrastructure.Implementation/CommandsService.Infrastructure.Implementation.csproj", "Source/CommandsService.Infrastructure.Implementation/"]
COPY ["Source/CommandsService.Infrastructure.Interfaces/CommandsService.Infrastructure.Interfaces.csproj", "Source/CommandsService.Infrastructure.Interfaces/"]
COPY ["Source/CommandsService.Persistence.EntityFramework/CommandsService.Persistence.EntityFramework.csproj", "Source/CommandsService.Persistence.EntityFramework/"]
RUN dotnet restore "Source/CommandsService.Entry.WebApi/CommandsService.Entry.WebApi.csproj"
COPY . .
WORKDIR "/src/Source/CommandsService.Entry.WebApi"
RUN dotnet build "CommandsService.Entry.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CommandsService.Entry.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CommandsService.Entry.WebApi.dll"]