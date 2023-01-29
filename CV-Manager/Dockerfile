#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CV-Manager/CV-Manager.csproj", "CV-Manager/"]
RUN dotnet restore "CV-Manager/CV-Manager.csproj"
COPY . .
WORKDIR "/src/CV-Manager"
RUN dotnet build "CV-Manager.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CV-Manager.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CV-Manager.dll"]