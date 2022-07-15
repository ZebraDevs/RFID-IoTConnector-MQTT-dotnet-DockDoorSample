using ZebraIoTConnector.DomainModel.Dto;

namespace ZebraIoTConnector.Persistence.Repositories
{
    public interface IEquipmentRepository
    {
        void AddIfNotExists(string equipmentName, string storageUnitName);
        EquipmentDto GetEquipmentByName(string name);
    }
}