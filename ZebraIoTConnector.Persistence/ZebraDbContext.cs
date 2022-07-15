using Microsoft.EntityFrameworkCore;
using ZebraIoTConnector.Persistence.Entities;

namespace ZebraIoTConnector.Persistence
{
    public class ZebraDbContext : DbContext
    {
        public DbSet<Equipment> Equipments { get; internal set; }
        public DbSet<StorageUnit> StorageUnits { get; internal set; }
        public DbSet<Sublot> Sublots { get; internal set; }
    }
}