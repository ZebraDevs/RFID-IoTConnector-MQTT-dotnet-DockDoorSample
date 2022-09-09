using Microsoft.EntityFrameworkCore;
using ZebraIoTConnector.Persistence.Entities;

namespace ZebraIoTConnector.Persistence
{
    public class ZebraDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=sql.data,1433;Database=ZebraRFID_DockDoor;MultipleActiveResultSets=true;User ID=sa;Password=Zebra2022!");
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

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Equipment> Equipments { get; internal set; }
        public DbSet<StorageUnit> StorageUnits { get; internal set; }
        public DbSet<Sublot> Sublots { get; internal set; }
        public DbSet<InventoryOperation> InventoryOperation { get; internal set; }
    }
}