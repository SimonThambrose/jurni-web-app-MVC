FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["JurniWebApp/JurniWebApp.csproj", "JurniWebApp/"]
RUN dotnet restore "JurniWebApp/JurniWebApp.csproj"
COPY . .
WORKDIR "/src/JurniWebApp"
RUN dotnet build "JurniWebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JurniWebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JurniWebApp.dll"]
