# .NET Core build stage
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
LABEL stage=builder
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

# Image build stage
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "PromTrial.dll"]
EXPOSE 80

