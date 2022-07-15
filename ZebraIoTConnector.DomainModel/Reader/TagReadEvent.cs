using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZebraIoTConnector.DomainModel.Reader
{
    public class TagReadEvent
    {
        public int EventNum { get; set; }

        public string Format { get; set; }

        public string IdHex { get; set; }
    }
}
