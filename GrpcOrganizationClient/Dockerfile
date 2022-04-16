#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GrpcOrganizationClient/GrpcOrganizationClient.csproj", "GrpcOrganizationClient/"]
RUN dotnet restore "GrpcOrganizationClient/GrpcOrganizationClient.csproj"
COPY . .
WORKDIR "/src/GrpcOrganizationClient"
RUN dotnet build "GrpcOrganizationClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GrpcOrganizationClient.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GrpcOrganizationClient.dll"]