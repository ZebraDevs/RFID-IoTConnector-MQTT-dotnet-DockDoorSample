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
            var sublots = zebraDbContext.Sublots.Where(x => sublotDtoList.Select(x => x.Id).Contains(x.Id))
                .Include(x => x.StorageUnit).ToList();

            foreach (var sublot in sublots)
            {
                zebraDbContext.Add(new InventoryOperation()
                {
                    Equipment = equipment,
                    Sublot = sublot,
                    UnitFrom = sublot.StorageUnit, // Unit from is where the pallet was located before.
                    UnitTo = destinationStorageUnit
                });
            }

            zebraDbContext.SaveChanges();
        }
    }
}
