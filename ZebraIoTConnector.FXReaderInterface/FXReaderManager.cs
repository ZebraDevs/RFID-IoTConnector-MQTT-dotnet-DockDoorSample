using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using ZebraIoTConnector.DomainModel.Reader;
using ZebraIoTConnector.Services;

namespace ZebraIoTConnector.FXReaderInterface
{
    public class FXReaderManager : IFXReaderManager
    {
        private readonly IEquipmentRegistryService equipmentRegistryService;
        private readonly IMaterialMovementService materialMovementService;

        public FXReaderManager(IEquipmentRegistryService equipmentRegistryService, IMaterialMovementService materialMovementService)
        {
            this.equipmentRegistryService = equipmentRegistryService ?? throw new ArgumentNullException(nameof(equipmentRegistryService));
            this.materialMovementService = materialMovementService ?? throw new ArgumentNullException(nameof(materialMovementService));
        }

        public static string GetConfiguration()
        {
            return Encoding.UTF8.GetString(Resources.ReaderConfig);
        }

        public static string GetOperationMode()
        {
            return Encoding.UTF8.GetString(Resources.ReaderMode);
        }
        public List<string> GetReaderNames()
        {
            return equipmentRegistryService.GetReaderNames();
        }

        public void HearthBeatEventReceived(HeartBeatEvent heartBeatEvent)
        {
            equipmentRegistryService.FXReaderHeartBeat(heartBeatEvent);
        }

        public void TagDataEventReceived(string clientId, List<TagReadEvent> tagReadEvent)
        {
            materialMovementService.NewTagReaded(clientId, tagReadEvent);
        }
        public void GPInStatusChanged()
        {
            // Send start reading command

            throw new NotImplementedException();
        }

    }
}
