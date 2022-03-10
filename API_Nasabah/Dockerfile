FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["API_Nasabah.csproj", "./"]
RUN dotnet restore "./API_Nasabah.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "API_Nasabah.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API_Nasabah.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API_Nasabah.dll"]
