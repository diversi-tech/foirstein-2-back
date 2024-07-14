#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER app
#WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081
#
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["webApi/WEBAPI.csproj", "webApi/"]
#COPY ["bll/BLL.csproj", "bll/"]
#COPY ["dal/DAL.csproj", "dal/"]
#RUN dotnet restore "./webApi/WEBAPI.csproj"
#COPY . .
#WORKDIR "/src/webApi"
#RUN dotnet build "./WEBAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "./WEBAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "WEBAPI.dll"]




# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# WORKDIR /app
# # העתקת כל קבצי ה-proj והפתרונות
# COPY *.sln ./
# COPY webApi/*.csproj ./webApi/
# COPY bll/*.csproj ./bll/
# COPY dal/*.csproj ./dal/
# # שחזור התלויות
# RUN dotnet restore
# # העתקת כל קבצי הפרויקט ובנייה
# COPY . ./
# WORKDIR /app/webApi
# RUN dotnet publish -c Release -o out
# # שלב 2: Run
# FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
# WORKDIR /app
# COPY --from=build /app/webApi/out ./
# ENV ASPNETCORE_URLS=http://+:8080
# EXPOSE 8080
# ENTRYPOINT ["dotnet", "webApi.dll"]


# #See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
# FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# WORKDIR /app
# EXPOSE 80
# EXPOSE 443
# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# WORKDIR /src
# COPY ["webApi/webApi.csproj", "webApi/"]
# COPY ["bll/BLL.csproj", "bll/"]
# COPY ["/dal/DAL.csproj", "dal/"]
# RUN dotnet restore "webApi/WEBAPI.csproj"
# COPY . .
# WORKDIR "/src/webApi"
# RUN dotnet build "webApi.csproj" -c Release -o /app/build
# FROM build AS publish
# RUN dotnet publish "webApi.csproj" -c Release -o /app/publish
# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "webApi.dll"]



#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["webApi/webApi.csproj", "webApi/"]
COPY ["bll/bll.csproj", "bll/"]
COPY ["dal/dal.csproj", "dal/"]
RUN dotnet restore "webApi/webApi.csproj"
COPY . .
WORKDIR "/src/webApi"
RUN dotnet build "webApi.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "webApi.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "webApi.dll"]
