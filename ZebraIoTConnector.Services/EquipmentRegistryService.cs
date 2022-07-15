using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZebraIoTConnector.DomainModel.Reader;
using ZebraIoTConnector.Persistence.Repositories;

namespace ZebraIoTConnector.Services
{
    public class EquipmentRegistryService : IEquipmentRegistryService
    {
        private readonly IEquipmentRepository equipmentRepository;

        public EquipmentRegistryService(IEquipmentRepository equipmentRepository)
        {
            this.equipmentRepository = equipmentRepository ?? throw new ArgumentNullException(nameof(equipmentRepository));
        }
        public void FXReaderHeartBeat(string clientId, HeartBeatEvent heartBeat)
        {
            string storageUnit = "";

            // These 2 storage units are added automatically on model creating for test purposes.
            if (clientId.EndsWith("_IN"))
                storageUnit = "DOCKDOOR_INBOUND";
            else
                storageUnit = "DOCKDOOR_OUTBOUND";

            equipmentRepository.AddIfNotExists(clientId, storageUnit);
        }
    }
}
