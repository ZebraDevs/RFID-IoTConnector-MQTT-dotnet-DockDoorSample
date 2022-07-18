#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ZebraIoTConnector.Client.MQTT.Console/ZebraIoTConnector.Client.MQTT.Console.csproj", "ZebraIoTConnector.Client.MQTT.Console/"]
COPY ["ZebraIoTConnector.FXReaderInterface/ZebraIoTConnector.FXReaderInterface.csproj", "ZebraIoTConnector.FXReaderInterface/"]
COPY ["ZebraIoTConnector.Services/ZebraIoTConnector.Services.csproj", "ZebraIoTConnector.Services/"]
COPY ["ZebraIoTConnector.Persistence/ZebraIoTConnector.Persistence.csproj", "ZebraIoTConnector.Persistence/"]
COPY ["ZebraIoTConnector.DomainModel/ZebraIoTConnector.DomainModel.csproj", "ZebraIoTConnector.DomainModel/"]
RUN dotnet restore "ZebraIoTConnector.Client.MQTT.Console/ZebraIoTConnector.Client.MQTT.Console.csproj"
COPY . .
WORKDIR "/src/ZebraIoTConnector.Client.MQTT.Console"
RUN dotnet build "ZebraIoTConnector.Client.MQTT.Console.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ZebraIoTConnector.Client.MQTT.Console.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ZebraIoTConnector.Client.MQTT.Console.dll"]