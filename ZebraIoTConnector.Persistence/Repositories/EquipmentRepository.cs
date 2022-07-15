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
                var storageUnit = zebraDbContext.StorageUnits.Single(x => x.Name == storageUnitName);
                zebraDbContext.Add(new Equipment()
                {
                    Name = equipmentName,
                    ReferenceStorageUnit = storageUnit
                });

                zebraDbContext.SaveChanges();
            }
        }

        public EquipmentDto GetEquipmentByName(string name)
        {
            var eq = zebraDbContext.Equipments
                .Include(x => x.ReferenceStorageUnit).Single(x => x.Name == name);
            return new EquipmentDto()
            {
                Id = eq.Id,
                Name = eq.Name,
                Description = eq.Description,
                RefStorageUnitName = eq.ReferenceStorageUnit.Name,
                RefStorageUnitDirection = eq.ReferenceStorageUnit.Direction
            };
        }
    }
}
