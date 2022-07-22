using ZebraIoTConnector.DomainModel.Dto;

namespace ZebraIoTConnector.Persistence.Repositories
{
    public interface IEquipmentRepository
    {
        void AddIfNotExists(string equipmentName, string storageUnitName);
        List<EquipmentDto> GetEquipments();
        EquipmentDto GetEquipmentByName(string name);
    }
}