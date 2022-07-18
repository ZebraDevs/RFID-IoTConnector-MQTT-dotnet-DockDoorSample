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
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferenceStorageUnitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipments_StorageUnits_ReferenceStorageUnitId",
                        column: x => x.ReferenceStorageUnitId,
                        principalTable: "StorageUnits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sublots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identifier = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "IX_Equipments_Name",
                table: "Equipments",
                column: "Name",
                unique: true);

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
                name: "IX_StorageUnits_Name",
                table: "StorageUnits",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sublots_Identifier",
                table: "Sublots",
                column: "Identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sublots_StorageUnitId",
                table: "Sublots",
                column: "StorageUnitId");


            migrationBuilder.Sql(Resources.InitScript);
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
