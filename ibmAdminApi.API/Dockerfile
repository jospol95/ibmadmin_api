#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["ibmAdminApi.API/ibmAdminApi.API.csproj", "ibmAdminApi.API/"]
RUN dotnet restore "ibmAdminApi.API/ibmAdminApi.API.csproj"
COPY . .
WORKDIR "/src/ibmAdminApi.API"
RUN dotnet build "ibmAdminApi.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ibmAdminApi.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ibmAdminApi.API.dll"]