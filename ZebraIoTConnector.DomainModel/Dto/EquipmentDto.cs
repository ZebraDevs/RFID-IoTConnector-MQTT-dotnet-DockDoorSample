using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZebraIoTConnector.DomainModel.Enums;

namespace ZebraIoTConnector.DomainModel.Dto
{
    public class EquipmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? RefStorageUnitName { get; set; }
        public Direction? RefStorageUnitDirection { get; set; }
    }
}
