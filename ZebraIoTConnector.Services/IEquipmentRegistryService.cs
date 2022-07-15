using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZebraIoTConnector.DomainModel.Reader;

namespace ZebraIoTConnector.Services
{
    public interface IEquipmentRegistryService
    {
        public void FXReaderHeartBeat(string clientId, HeartBeatEvent heartBeat);
    }
}
