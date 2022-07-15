using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZebraIoTConnector.Persistence.Entities
{
    public class InventoryOperation
    {
        public int Id { get; set; }
        public Sublot Sublot { get; set; }
        public StorageUnit UnitFrom { get; set; }
        public StorageUnit UnitTo { get; set; }
        public Equipment Equipment { get; set; }
    }
}
