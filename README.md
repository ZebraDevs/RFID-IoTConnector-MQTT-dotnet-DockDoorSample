# Zebra RFID IoT Connector - MQTT - Dock Door Sample

## Concept
```
----------------|             |----------------
Warehouse 1     |             |     Warehouse 2
                |             |
                |             |   
                
    DOCK DOOR OUT   ------>   DOCK DOOR IN		
 
                |             |   
    FX READER 1 |             | FX READER 2  
                |             |                
----------------|             |----------------
```

This sample is based on the fixed reader dock door use case.
Basically, pallets from Warehouse 1 are transferred to Warehouse 2 passing thru a dock door.
Each dock door has a fixed RFID reader that reads all the tags passing by.
When a reading event is triggered, this application:
- Create a Sublot with the read tag as identifier (if not exists).
- Identify the movement direction based on the equipment (the reader).
- Move the Sublot either to a generic "Truck" Storage Unit (outbound) or to the Warehouse 2 Storage Unit (inbound) upond movement direction.

This demo provides a set of data already configured:
- Warehouse 1, Warehouse 2, and Truck Storage Units.
- A reader on the out position named "myfxOUT" (outbound direction).
- A reader on the out position named "myfxIN" (inbound direction).

To use this default setup, the MQTT configuration of your reader should be setup accordingly (see setup section).

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


## Connect yours RFID Readers

### Prerequisites
- Supported Readers FX7500, FX9600, ATR7000
- Firmware version 3.10.30 or above
- Reader connected to the same network of your local machine

### Setup
- Follow MQTT endpoint configuration guide: https://zebradevs.github.io/rfid-ziotc-docs/other_cloud_support/MQTT/web.html.
- Use your local machine IP as Server Address.
- Default port is 1883.
- Topics should have the following format to work with this demo: "zebra/{your reader name}/{topic name}". Topic names must be:

| Endpoint          | Topic			|
| -------------     |   :---:   |
|Management Events  | events	  |
|Tag Data Events    | data		  |
|Management Command	| mgmt/cmd	|
|ManagementResponse	| mgmt/res	|
|Control Command	  | ctrl/cmd	|
|Control Response	  | ctrl/res	|

- If you want to use the pre-defined setup of this demo (without configuring the readers manually), your topics should use the following reader names:
  - "myfxOUT" for the reader at Warehouse 1 (e.g."zebra/myfxOUT/events")
  - "myfxIN" for the reader at Warehouse 2 (e.g."zebra/myfxIN/events")
  - If you want to configure your reader manually, you have to edit the Equipments table from SQL Server adding your readers.

#### Connection Setup
![image](https://user-images.githubusercontent.com/101400857/180752287-0b3665b9-24d1-4b24-a87e-62c719e3e0a1.png)
![image](https://user-images.githubusercontent.com/101400857/180755415-9a43a8de-f705-48f8-b6a5-9a8248ed9efd.png)

#### Topic Setup
![image](https://user-images.githubusercontent.com/101400857/180752210-b31faf90-e091-493c-b3a0-75340c280895.png)

Now your reader is connected to our Demo app.
Start reading tags and enjoy.

## Project Structure

### Docker

- **zebraiotconnector.client.mqtt.console** MQTT Client (Core business logic)
- **sql.data** SQL Server instance
- **mosquitto** MQTT Broker 

### Solution

- ZebraIoTConnector.Client.MQTT.Console: MQTT Client for our reader
- ZebraIoTConnector.DomainModel: DTO (Data Transfer Object) to pass across layers
- ZebraIoTConnector.FXReaderInterface: Additional layer to make business logic independent from the way we communicate with the reader (MQTT, HTTP etc.)
- ZebraIoTConnector.Persistence: DAL (Data Access Layer) Entity Framework is used as ORM
- ZebraIoTConnector.Services: Core business logic.

### Database

- __EFMigrationsHistory: Entity Framework schema comparison
- Equipments: Contains the readers to be used
- InventoryOperations: Registers each movement of Sublot (our tag) between readers.
- StorageUnits: Warehouse locations
- Sublots: Full Inventory (our tags)

# License

[MIT](LICENSE.txt)
