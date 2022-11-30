#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Source/PlatformService.Entry.WebApi/PlatformService.Entry.WebApi.csproj", "Source/PlatformService.Entry.WebApi/"]
COPY ["Source/PlatformService.Application/PlatformService.Application.csproj", "Source/PlatformService.Application/"]
COPY ["Source/PlatformService.Core/PlatformService.Core.csproj", "Source/PlatformService.Core/"]
COPY ["Source/PlatformService.Persistence.Interfaces/PlatformService.Persistence.Interfaces.csproj", "Source/PlatformService.Persistence.Interfaces/"]
COPY ["Source/PlatformService.Entry/PlatformService.Entry.csproj", "Source/PlatformService.Entry/"]
COPY ["Source/PlatformService.Persistence.EntityFramework/PlatformService.Persistence.EntityFramework.csproj", "Source/PlatformService.Persistence.EntityFramework/"]
RUN dotnet restore "Source/PlatformService.Entry.WebApi/PlatformService.Entry.WebApi.csproj"
COPY . .
WORKDIR "/src/Source/PlatformService.Entry.WebApi"
RUN dotnet build "PlatformService.Entry.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PlatformService.Entry.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PlatformService.Entry.WebApi.dll"]