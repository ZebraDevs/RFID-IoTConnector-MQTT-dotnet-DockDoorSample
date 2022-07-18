using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZebraIoTConnector.Persistence.Entities
{
    public class InventoryOperation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Sublot Sublot { get; set; }
        public StorageUnit StorageUnitFrom { get; set; }
        public StorageUnit StorageUnitTo { get; set; }
        public Equipment Equipment { get; set; }
    }
}
