# Zebra RFID IoTConnector - Dock Door Sample

## Concept
```
----------------|             |----------------
Warehouse 1     |             |     Warehouse 2
                |             |
                |             |   
                
        DOCK1 OUT   ------>   DOCK1 IN		
 
                |             |   
    FX READER 1 |             | FX READER 2  
                |             |                
----------------|             |----------------
```

# Setup

## Docker Container

### Prerequisites
- Docker (installation guide: https://docs.docker.com/desktop/install/windows-install/)

### Setup
Run the following command within the main project directory.
```
docker compose up
```
Once the container is up and running, you can connect your reader.


## Connect the RFID Reader

### Prerequisites
- Supported Readers FX7500, FX9600, ATR7000
- Firmware version 3.10.30 or above
- Reader connected to the same network of your local machine

### Setup
- Follow MQTT endpoint configuration guide: https://zebradevs.github.io/rfid-ziotc-docs/other_cloud_support/MQTT/web.html
- Use your local machine IP Address as Server.

Now your reader is connected to our Demo app.
Start reading tags and enjoy.

## Project Structure

### Docker Compose

- **zebraiotconnector.client.mqtt.console** MQTT Client (Core business logic)
- **sql.data** SQL Server instance
- **mosquitto** MQTT Broker 

WIP
