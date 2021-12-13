#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
#API Project
COPY ["GameCollectionApi/GameCollectionApi.csproj", "GameCollectionApi/"]
#Core Project
COPY ["CoreLibrary/CoreLibrary.csproj", "CoreLibrary/"]
#Game Collection Library Project
COPY ["GameCollection/GameCollection.csproj", "GameCollection/"]
#EntityFrameworkCore Repository Project
COPY ["CoreLibrary.EfRepository/CoreLibrary.EfRepository.csproj", "CoreLibrary.EfRepository/"]
RUN dotnet restore "GameCollectionApi/GameCollectionApi.csproj"
COPY . .
WORKDIR "/src/GameCollectionApi"
RUN dotnet build "GameCollectionApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GameCollectionApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameCollectionApi.dll"]