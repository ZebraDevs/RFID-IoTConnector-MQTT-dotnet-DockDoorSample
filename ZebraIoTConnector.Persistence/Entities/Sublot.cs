using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZebraIoTConnector.Persistence.Entities
{
    [Index(nameof(Identifier), IsUnique = true)]
    public class Sublot
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string MaterialId { get; set; }
        public string BatchNumber { get; set; }
        public StorageUnit StorageUnit { get; set; }
        public DateTime ProductionDate { get; set; }
    }
}
