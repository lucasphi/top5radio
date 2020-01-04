FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY Top5Radio.API.csproj Top5Radio.API/
COPY . .
RUN dotnet restore "Top5Radio.API.csproj"
WORKDIR /src/Top5Radio.API
RUN dotnet build "Top5Radio.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Top5Radio.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Top5Radio.API.dll"]