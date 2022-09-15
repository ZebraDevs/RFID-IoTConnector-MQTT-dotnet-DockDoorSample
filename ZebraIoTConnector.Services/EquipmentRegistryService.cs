using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZebraIoTConnector.DomainModel.Reader;
using ZebraIoTConnector.Persistence;
using ZebraIoTConnector.Persistence.Repositories;

namespace ZebraIoTConnector.Services
{
    public class EquipmentRegistryService : IEquipmentRegistryService
    {
        private readonly IUnitOfWork unitOfWork;

        public EquipmentRegistryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public void CreateReaderIfNotExists(HeartBeatEvent heartBeat)
        {
            // Add reader if it does not exists.
            // Storage Unit to be configured manually
            unitOfWork.EquipmentRepository.AddIfNotExists(heartBeat.ClientId, null);
        }
        public bool IsConfigured(string readerName)
        {
            return unitOfWork.EquipmentRepository.GetEquipmentByName(readerName).IsConfigured;
        }
        public void SetReaderConfigured(string readerName)
        {
            unitOfWork.EquipmentRepository.SetReaderConfigured(readerName);
        }
        public List<string> GetReaderNames()
        {
            return unitOfWork.EquipmentRepository.GetEquipments().Select(x => x.Name).ToList();
        }
    }
}
