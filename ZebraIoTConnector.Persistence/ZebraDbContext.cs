using Microsoft.EntityFrameworkCore;
using ZebraIoTConnector.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace ZebraIoTConnector.Persistence
{
    public class ZebraDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=host.docker.internal,1433;Database=ZebraRFID_DockDoor;MultipleActiveResultSets=true;User ID=sa;Password=Zebra2022!");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InventoryOperation>()
                .HasOne(e => e.StorageUnitFrom)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<InventoryOperation>()
                .HasOne(e => e.StorageUnitTo)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<InventoryOperation>()
                .HasOne(e => e.Sublot)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<InventoryOperation>()
                .HasOne(e => e.Equipment)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            //var dockOutWH1 = new StorageUnit()
            //{
            //    Id = 1,
            //    Name = "DOCK_OUT_WH1",
            //    Description = "DockDoor_Warehouse1",
            //    Direction = DomainModel.Enums.Direction.Outbound
            //};
            //var wh1 = new StorageUnit()
            //{
            //    Id = 2,
            //    Name = "WH1",
            //    Description = "Main WH1",
            //    Direction = DomainModel.Enums.Direction.Outbound
            //};
            //var dockInWH2 = new StorageUnit()
            //{
            //    Id = 3,
            //    Name = "DOCK_IN_WH2",
            //    Description = "DockDoor_Warehouse2",
            //    Direction = DomainModel.Enums.Direction.Inbound
            //};
            //var truck = new StorageUnit()
            //{
            //    Id = 4,
            //    Name = "TRUCK",
            //    Description = "TRUCK",
            //    Direction = DomainModel.Enums.Direction.Inbound
            //};
            //modelBuilder.Entity<StorageUnit>()
            //    .HasData(dockOutWH1, dockInWH2, truck, wh1);

            //modelBuilder.Entity<Equipment>()
            //    .HasData(new Equipment()
            //    {
            //        Id = 1,
            //        Name = "myfx",
            //        Description = "My Reader OUT WH1 (add yours or change name)",
            //        ReferenceStorageUnit = dockOutWH1
            //    },
            //    new Equipment()
            //    {
            //        Id = 2,
            //        Name = "myfx",
            //        Description = "My Reader IN WH2 (add yours or change name)",
            //        ReferenceStorageUnit = dockInWH2
            //    });

            //modelBuilder.Entity<Sublot>()
            //    .HasData(new Sublot()
            //    {
            //        Id = 1,
            //        MaterialId = "123456789",
            //        BatchNumber = "00987654321",
            //        ProductionDate = DateTime.Now,
            //        StorageUnit = wh1
            //    });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Equipment> Equipments { get; internal set; }
        public DbSet<StorageUnit> StorageUnits { get; internal set; }
        public DbSet<Sublot> Sublots { get; internal set; }
        public DbSet<InventoryOperation> InventoryOperation { get; internal set; }
    }
}