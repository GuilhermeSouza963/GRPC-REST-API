FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["TccDev.Api/TccDev.Api.csproj", "TccDev.Api/"]
RUN dotnet restore "TccDev.Api/TccDev.Api.csproj"
COPY . .
WORKDIR "/src/TccDev.Api"
RUN dotnet build "TccDev.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TccDev.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TccDev.Api.dll"]