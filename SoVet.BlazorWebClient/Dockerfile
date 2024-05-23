FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SoVet.BlazorWebClient/SoVet.BlazorWebClient.csproj", "SoVet.BlazorWebClient/"]
RUN dotnet restore "SoVet.BlazorWebClient/SoVet.BlazorWebClient.csproj"

COPY . .
WORKDIR "/src/SoVet.BlazorWebClient/"
RUN dotnet build "SoVet.BlazorWebClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SoVet.BlazorWebClient.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM nginx:alpine as final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY SoVet.BlazorWebClient/nginx.conf /etc/nginx/nginx.conf
CMD ["nginx", "-g", "daemon off;"]
