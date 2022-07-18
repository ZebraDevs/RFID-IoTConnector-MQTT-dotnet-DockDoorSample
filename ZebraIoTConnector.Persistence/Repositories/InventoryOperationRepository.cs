using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZebraIoTConnector.DomainModel.Dto;
using ZebraIoTConnector.Persistence.Entities;

namespace ZebraIoTConnector.Persistence.Repositories
{
    public class InventoryOperationRepository : IInventoryOperationRepository
    {
        private readonly ZebraDbContext zebraDbContext;

        public InventoryOperationRepository(ZebraDbContext zebraDbContext)
        {
            this.zebraDbContext = zebraDbContext ?? throw new ArgumentNullException(nameof(zebraDbContext));
        }

        public void AddInventoryOperation(List<SublotDto> sublotDtoList, string destinationStoragrUnitName, EquipmentDto equipmentDto)
        {
            var equipment = zebraDbContext.Equipments.Single(x => x.Id == equipmentDto.Id);
            var destinationStorageUnit = zebraDbContext.StorageUnits.Single(x => x.Name == destinationStoragrUnitName);
            var sublots = zebraDbContext.Sublots.Where(x => sublotDtoList.Select(x => x.Identifier).Contains(x.Identifier))
                .Include(x => x.StorageUnit).ToList();

            foreach (var sublot in sublots)
            {
                zebraDbContext.InventoryOperation.Add(new InventoryOperation()
                {
                    Equipment = equipment,
                    Sublot = sublot,
                    StorageUnitFrom = sublot.StorageUnit, // Unit from is where the pallet was located before.
                    StorageUnitTo = destinationStorageUnit
                });
            }

            zebraDbContext.SaveChanges();
        }
    }
}
