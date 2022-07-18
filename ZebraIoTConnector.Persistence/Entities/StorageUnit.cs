using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using ZebraIoTConnector.DomainModel.Enums;

namespace ZebraIoTConnector.Persistence.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class StorageUnit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Direction Direction { get; set; }
    }

}
