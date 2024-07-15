# See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
EXPOSE 80
EXPOSE 443
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["webApi/webApi.csproj", "webApi/"]
COPY ["bll/bll.csproj", "bll/"]
COPY ["dal/dal.csproj", "dal/"]
RUN dotnet restore "webApi/webApi.csproj" --force
COPY . .
WORKDIR "/src/webApi"
RUN dotnet build "webApi.csproj" -o /app/build --force
FROM build AS publish
RUN dotnet publish "webApi.csproj" -c Release -o /app/publish --force
FROM base AS final 
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "webApi.dll"]
