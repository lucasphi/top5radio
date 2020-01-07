FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY . Top5Radio.Admin/
RUN dotnet restore "Top5Radio.Admin/Top5Radio.Admin.csproj"
WORKDIR /src/Top5Radio.Admin/
RUN dotnet build "Top5Radio.Admin.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Top5Radio.Admin.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Top5Radio.Admin.dll"]