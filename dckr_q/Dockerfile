FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["dckr_q/dckr_q.csproj", "dckr_q/"]
RUN dotnet restore "dckr_q/dckr_q.csproj"
COPY . .
WORKDIR "/src/dckr_q"
RUN dotnet build "dckr_q.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dckr_q.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dckr_q.dll"]
