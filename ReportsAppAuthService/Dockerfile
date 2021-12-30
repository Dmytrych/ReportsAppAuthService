FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ReportsAppAuthService/ReportsAppAuthService.csproj", "ReportsAppAuthService/"]
RUN dotnet restore "ReportsAppAuthService/ReportsAppAuthService.csproj"
COPY . .
WORKDIR "/src/ReportsAppAuthService"
RUN dotnet build "ReportsAppAuthService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReportsAppAuthService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReportsAppAuthService.dll"]
