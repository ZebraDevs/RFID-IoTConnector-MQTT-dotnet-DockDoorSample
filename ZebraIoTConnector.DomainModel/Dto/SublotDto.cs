using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZebraIoTConnector.DomainModel.Dto
{
    public class SublotDto
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string MaterialId { get; set; }
        public string BatchNumber { get; set; }
        public string StorageUnitName { get; set; }
        public DateTime ProductionDate { get; set; }
    }
}
