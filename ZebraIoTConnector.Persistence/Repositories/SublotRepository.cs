using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZebraIoTConnector.DomainModel.Dto;

namespace ZebraIoTConnector.Persistence.Repositories
{
    public class SublotRepository : ISublotRepository
    {
        private readonly ZebraDbContext zebraDbContext;

        public SublotRepository(ZebraDbContext zebraDbContext)
        {
            this.zebraDbContext = zebraDbContext ?? throw new ArgumentNullException(nameof(zebraDbContext));
        }
        public List<SublotDto> GetOrCreateSublotByIdentifier(string creationUnit, params string[] identifiers)
        {
            // Get existing sublots
            var sublots = zebraDbContext.Sublots.Where(x => identifiers.Contains(x.Identifier))
                .Include(x => x.StorageUnit)
                .ToList();

            // Check for missing sublots and create them if needed
            var missingIds = identifiers.Except(sublots.Select(x => x.Identifier));
            if (missingIds.Any())
            {
                // Retrieve storage unit where to create sublots (reader location)
                var storageUnit = zebraDbContext.StorageUnits.Single(x => x.Name == creationUnit);

                foreach (var sublotIdentifier in missingIds)
                {
                    sublots.Add(zebraDbContext.Sublots.Add(new Entities.Sublot()
                    {
                        Identifier = sublotIdentifier,
                        MaterialId = "123456789",
                        BatchNumber = "00987654321",
                        StorageUnit = storageUnit,
                        ProductionDate = DateTime.Now
                    })
                    .Entity);
                }
            }

            // Return existing + created sublots
            return sublots.Select(x => new SublotDto()
            {
                Id = x.Id,
                Identifier = x.Identifier,
                MaterialId = x.MaterialId,
                BatchNumber = x.BatchNumber,
                StorageUnitName = x.StorageUnit.Name,
                ProductionDate = x.ProductionDate
            }).ToList();
        }

        public void MoveSublots(List<SublotDto> sublotDtoList, string newStorageUnit)
        {
            var storageUnit = zebraDbContext.StorageUnits.Single(x => x.Name == newStorageUnit);
            var sublots = zebraDbContext.Sublots.Where(x => sublotDtoList.Select(x => x.Id).Contains(x.Id))
                .Include(x => x.StorageUnit).ToList();

            foreach (var sublot in sublots)
                sublot.StorageUnit = storageUnit;

            zebraDbContext.SaveChanges();
        }
    }
}
