using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZebraIoTConnector.Persistence.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StorageUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferenceStorageUnitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipments_StorageUnits_ReferenceStorageUnitId",
                        column: x => x.ReferenceStorageUnitId,
                        principalTable: "StorageUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sublots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatchNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StorageUnitId = table.Column<int>(type: "int", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sublots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sublots_StorageUnits_StorageUnitId",
                        column: x => x.StorageUnitId,
                        principalTable: "StorageUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryOperation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SublotId = table.Column<int>(type: "int", nullable: false),
                    StorageUnitFromId = table.Column<int>(type: "int", nullable: false),
                    StorageUnitToId = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryOperation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryOperation_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryOperation_StorageUnits_StorageUnitFromId",
                        column: x => x.StorageUnitFromId,
                        principalTable: "StorageUnits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryOperation_StorageUnits_StorageUnitToId",
                        column: x => x.StorageUnitToId,
                        principalTable: "StorageUnits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryOperation_Sublots_SublotId",
                        column: x => x.SublotId,
                        principalTable: "Sublots",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_ReferenceStorageUnitId",
                table: "Equipments",
                column: "ReferenceStorageUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOperation_EquipmentId",
                table: "InventoryOperation",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOperation_StorageUnitFromId",
                table: "InventoryOperation",
                column: "StorageUnitFromId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOperation_StorageUnitToId",
                table: "InventoryOperation",
                column: "StorageUnitToId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOperation_SublotId",
                table: "InventoryOperation",
                column: "SublotId");

            migrationBuilder.CreateIndex(
                name: "IX_Sublots_StorageUnitId",
                table: "Sublots",
                column: "StorageUnitId");

            migrationBuilder.Sql(
                @"USE [ZebraRFID_DockDoor]
                GO
                SET IDENTITY_INSERT[dbo].[StorageUnits] ON
                GO
                INSERT[dbo].[StorageUnits]([Id], [Name], [Description], [Direction]) VALUES(1, N'DOCK_OUT_WH1', N'DockDoor_Warehouse1', 2)
                GO
                INSERT[dbo].[StorageUnits] ([Id], [Name], [Description], [Direction]) VALUES(2, N'DOCK_IN_WH2', N'DockDoor_Warehouse2', 1)
                GO
                INSERT[dbo].[StorageUnits] ([Id], [Name], [Description], [Direction]) VALUES(3, N'TRUCK', N'TRUCK', 1)
                GO
                INSERT[dbo].[StorageUnits] ([Id], [Name], [Description], [Direction]) VALUES(4, N'WH1', N'Main WH1', 2)
                GO
                INSERT[dbo].[StorageUnits] ([Id], [Name], [Description], [Direction]) VALUES(9, N'DOCK_OUT_WH1', N'DockDoor_Warehouse1', 2)
                GO
                INSERT[dbo].[StorageUnits] ([Id], [Name], [Description], [Direction]) VALUES(10, N'DOCK_IN_WH2', N'DockDoor_Warehouse2', 1)
                GO
                INSERT[dbo].[StorageUnits] ([Id], [Name], [Description], [Direction]) VALUES(11, N'TRUCK', N'TRUCK', 1)
                GO
                INSERT[dbo].[StorageUnits] ([Id], [Name], [Description], [Direction]) VALUES(12, N'WH1', N'Main WH1', 2)
                GO
                SET IDENTITY_INSERT[dbo].[StorageUnits] OFF
                GO
                SET IDENTITY_INSERT[dbo].[Equipments] ON
                GO
                INSERT[dbo].[Equipments]([Id], [Name], [Description], [ReferenceStorageUnitId]) VALUES(5, N'myfx', N'My Reader OUT WH1 (add yours or change name)', 9)
                GO
                INSERT[dbo].[Equipments] ([Id], [Name], [Description], [ReferenceStorageUnitId]) VALUES(6, N'myfx', N'My Reader IN WH2 (add yours or change name)', 10)
                GO
                SET IDENTITY_INSERT[dbo].[Equipments] OFF
                GO
                SET IDENTITY_INSERT[dbo].[Sublots] ON
                GO
                INSERT[dbo].[Sublots]([Id], [Identifier], [MaterialId], [BatchNumber], [StorageUnitId], [ProductionDate]) VALUES(3, N'8119cb0d0a9acb0d0a9a0000', N'123456789', N'00987654321', 12, CAST(N'2022-07-18T12:30:52.1342280' AS DateTime2))
                GO
                SET IDENTITY_INSERT[dbo].[Sublots] OFF
                GO
                ");     
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryOperation");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Sublots");

            migrationBuilder.DropTable(
                name: "StorageUnits");
        }
    }
}
