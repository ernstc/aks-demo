#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DemoWebApp2.csproj", "DemoWebApp2/"]
RUN dotnet restore "DemoWebApp2/DemoWebApp2.csproj"
WORKDIR "/src/DemoWebApp2"
COPY . .
RUN dotnet build "DemoWebApp2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DemoWebApp2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DemoWebApp2.dll"]