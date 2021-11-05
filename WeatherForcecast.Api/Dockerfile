FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
LABEL Description=".NET Core 3.1 Project" Vendor="Microsoft" Version="3.1"
WORKDIR /app               
EXPOSE 5000

ENV ASPNETCORE_URLS=http://localhost:5000

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["WeatherForcecast.Api/Weather.Api.csproj", "WeatherForcecast.Api/"]
RUN dotnet restore "WeatherForcecast.Api\Weather.Api.csproj"
COPY . .                                             
WORKDIR "/src/WeatherForcecast.Api"
RUN dotnet build "Weather.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Weather.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Weather.Api.dll"]



