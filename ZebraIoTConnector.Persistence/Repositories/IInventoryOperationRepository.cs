using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZebraIoTConnector.DomainModel.Dto;

namespace ZebraIoTConnector.Persistence.Repositories
{
    public interface IInventoryOperationRepository
    {
        public void AddInventoryOperation(List<SublotDto> sublotDtoList, string destinationStorageUnit, EquipmentDto equipmentDto);
    }
}
