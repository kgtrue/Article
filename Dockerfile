#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Articles.API/Articles.API.csproj", "src/Articles.API/"]
COPY ["src/Articles.Persistence/Articles.Persistence.csproj", "src/Articles.Persistence/"]
COPY ["src/Articles.Core.Application/Articles.Core.Application.csproj", "src/Articles.Core.Application/"]
COPY ["src/Articles.Core/Articles.Core.csproj", "src/Articles.Core/"]
COPY ["src/Articles.Core.Tests/Articles.Core.Tests.csproj", "src/Articles.Core.Tests/"]
COPY ["src/Articles.Core.Application.Tests/Articles.Core.Application.Tests.csproj", "src/Articles.Core.Application.Tests/"]
RUN dotnet restore "src/Articles.Core.Tests/Articles.Core.Tests.csproj"
RUN dotnet build "src/Articles.Core.Tests/Articles.Core.Tests.csproj" -c Release
RUN dotnet restore "src/Articles.Core.Application.Tests/Articles.Core.Application.Tests.csproj
RUN dotnet build "src/Articles.Core.Application.Tests/Articles.Core.Application.Tests.csproj" -c Release
RUN dotnet restore "src/Articles.API/Articles.API.csproj"
WORKDIR "/src/src/Articles.Core.Tests"
RUN dotnet test "Articles.Core.Tests.csproj"
WORKDIR "/src/src/Articles.Core.Application.Tests"
RUN dotnet test "Articles.Core.Application.Tests.csproj"
WORKDIR /src



COPY . .
WORKDIR "/src/src/Articles.API"
RUN dotnet build "Articles.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Articles.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Articles.API.dll"]