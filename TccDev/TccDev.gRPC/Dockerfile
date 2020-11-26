FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["TccDev.gRPC/TccDev.gRPC.csproj", "TccDev.gRPC/"]
RUN dotnet restore "TccDev.gRPC/TccDev.gRPC.csproj"
COPY . .
WORKDIR "/src/TccDev.gRPC"
RUN dotnet build "TccDev.gRPC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TccDev.gRPC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TccDev.gRPC.dll"]