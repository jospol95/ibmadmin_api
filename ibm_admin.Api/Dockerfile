#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["ibm_admin.Api/ibm_admin.Api.csproj", "ibm_admin.Api/"]
RUN dotnet restore "ibm_admin.Api/ibm_admin.Api.csproj"
COPY . .
WORKDIR "/src/ibm_admin.Api"
RUN dotnet build "ibm_admin.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ibm_admin.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ibm_admin.Api.dll"]