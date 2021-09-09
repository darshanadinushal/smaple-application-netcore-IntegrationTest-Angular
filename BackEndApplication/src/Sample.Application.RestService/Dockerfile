#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/Sample.Application.RestService/Sample.Application.RestService.csproj", "src/Sample.Application.RestService/"]
COPY ["src/Sample.Application.Manager/Sample.Application.Manager.csproj", "src/Sample.Application.Manager/"]
COPY ["src/Sample.Application.Core/Sample.Application.Core.csproj", "src/Sample.Application.Core/"]
COPY ["src/Sample.Application.Shared/Sample.Application.Shared.csproj", "src/Sample.Application.Shared/"]
RUN dotnet restore "src/Sample.Application.RestService/Sample.Application.RestService.csproj"
COPY . .
WORKDIR "/src/src/Sample.Application.RestService"
RUN dotnet build "Sample.Application.RestService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sample.Application.RestService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sample.Application.RestService.dll"]