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
        public void CreateReaderIfNotExists(HeartBeatEvent heartBeat);
        bool IsConfigured(string readerName);
        void SetReaderConfigured(string readerName);
        List<string> GetReaderNames();
    }
}
