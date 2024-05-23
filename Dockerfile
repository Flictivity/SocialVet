FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY SoVet.sln ./
COPY SoVet.Auth/*.csproj ./SoVet.Auth/
RUN dotnet restore "SoVet.Auth/SoVet.Auth.csproj"

COPY SoVet.Data/*.csproj ./SoVet.Data/
RUN dotnet restore "SoVet.Data/SoVet.Data.csproj"

COPY SoVet.Domain/*.csproj ./SoVet.Domain/
RUN dotnet restore "SoVet.Domain/SoVet.Domain.csproj"

COPY SoVet.WebAPI/*.csproj ./SoVet.WebAPI/
RUN dotnet restore "SoVet.WebAPI/SoVet.WebAPI.csproj"

COPY . .

WORKDIR "/src/SoVet.Auth"
RUN dotnet build "SoVet.Auth.csproj" -c Release -o /app/build

WORKDIR "/src/SoVet.Data"
RUN dotnet build "SoVet.Data.csproj" -c Release -o /app/build

WORKDIR "/src/SoVet.Domain"
RUN dotnet build "SoVet.Domain.csproj" -c Release -o /app/build

WORKDIR "/src/SoVet.WebAPI"
RUN dotnet build "SoVet.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SoVet.WebAPI.dll"]
