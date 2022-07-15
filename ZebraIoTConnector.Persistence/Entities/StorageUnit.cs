using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZebraIoTConnector.DomainModel.Enums;

namespace ZebraIoTConnector.Persistence.Entities
{
    public class StorageUnit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Direction Direction { get; set; }
    }

}
