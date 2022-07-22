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
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly ZebraDbContext zebraDbContext;

        public EquipmentRepository(ZebraDbContext zebraDbContext)
        {
            this.zebraDbContext = zebraDbContext ?? throw new ArgumentNullException(nameof(zebraDbContext));
        }

        public void AddIfNotExists(string equipmentName, string storageUnitName)
        {
            var eq = zebraDbContext.Equipments.SingleOrDefault(x => x.Name == equipmentName);
            if (eq == null)
            {
                var storageUnit = zebraDbContext.StorageUnits.SingleOrDefault(x => x.Name == storageUnitName);
                zebraDbContext.Add(new Equipment()
                {
                    Name = equipmentName,
                    ReferenceStorageUnit = storageUnit
                });

                zebraDbContext.SaveChanges();
            }
        }

        public List<EquipmentDto> GetEquipments()
        {
            return zebraDbContext.Equipments
                .Include(x => x.ReferenceStorageUnit)
                .Select(eq => new EquipmentDto()
                {
                    Id = eq.Id,
                    Name = eq.Name,
                    Description = eq.Description,
                    RefStorageUnitName = eq.ReferenceStorageUnit == null ? "" : eq.ReferenceStorageUnit.Name,
                    RefStorageUnitDirection = eq.ReferenceStorageUnit == null ? DomainModel.Enums.Direction.None : eq.ReferenceStorageUnit.Direction
                })
                .ToList();
        }
        public EquipmentDto GetEquipmentByName(string name)
        {
            var eq = zebraDbContext.Equipments
                .Include(x => x.ReferenceStorageUnit).SingleOrDefault(x => x.Name == name);

            if (eq == null)
                return null;

            return new EquipmentDto()
            {
                Id = eq.Id,
                Name = eq.Name,
                Description = eq.Description,
                RefStorageUnitName = eq.ReferenceStorageUnit?.Name,
                RefStorageUnitDirection = eq.ReferenceStorageUnit?.Direction
            };
        }
    }
}
