using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZebraIoTConnector.Persistence.Entities
{
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
