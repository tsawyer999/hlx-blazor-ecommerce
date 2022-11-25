#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Hollox.BlazorEcommerce/Hollox.BlazorEcommerce.csproj", "Hollox.BlazorEcommerce/"]
RUN dotnet restore "Hollox.BlazorEcommerce/Hollox.BlazorEcommerce.csproj"
COPY . .
WORKDIR "/src/Hollox.BlazorEcommerce"
RUN dotnet build "Hollox.BlazorEcommerce.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hollox.BlazorEcommerce.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hollox.BlazorEcommerce.dll"]