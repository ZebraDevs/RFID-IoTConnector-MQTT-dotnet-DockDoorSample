using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZebraIoTConnector.DomainModel.Enums;
using ZebraIoTConnector.DomainModel.Reader;
using ZebraIoTConnector.Persistence;
using ZebraIoTConnector.Persistence.Repositories;

namespace ZebraIoTConnector.Services
{
    public class MaterialMovementService : IMaterialMovementService
    {
        private readonly ILogger<MaterialMovementService> logger;
        private readonly IUnitOfWork unitOfWork;

        public MaterialMovementService(ILogger<MaterialMovementService> logger, IUnitOfWork unitOfWork)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public void NewTagReaded(string clientId, List<TagReadEvent> tagReadEvent)
        {
            // Retrieve equipment by name (clientId).
            var reader = unitOfWork.EquipmentRepository.GetEquipmentByName(clientId);

            if(reader == null)
            {
                // reader not registered yet, tag read message received before the hearbeat
                logger.LogWarning($"Reader {clientId} not registered yet, tag read message received before the hearbeat");
                return;
            }

            if (string.IsNullOrEmpty(reader.RefStorageUnitName))
            {
                // DO NOTHING
                // Storage Unit is not configured for this reader
                logger.LogWarning($"Storage Unit has to be configured manually so that reader '{clientId}' can be used");
                return;
            }

            // Retrieve sublots associated to readed epcs or create them.
            var sublots = unitOfWork.SublotRepository.GetOrCreateSublotByIdentifier(reader.RefStorageUnitName, tagReadEvent.Select(x => x.IdHex).ToArray());
            
            // Check direction of Equipment storage unit
            // Move sublots either on WH or Truck upon Storage Unit direction.

            var destinationStorageUnit = reader.RefStorageUnitName;
            if (reader.RefStorageUnitDirection == Direction.Outbound)
                destinationStorageUnit = "TRUCK"; // Added for testing purposes on model creating

            
            // Persists data within transaction.
            unitOfWork.BeginTransaction();

            try
            {
                // Create inventory order
                unitOfWork.InventoryOperationRepository.AddInventoryOperation(sublots, destinationStorageUnit, reader);

                // Move sublots in the proper storage unit
                unitOfWork.SublotRepository.MoveSublots(sublots, destinationStorageUnit);

                // Commit the transaction
                unitOfWork.CommitTransaction();
                foreach (var sublot in sublots)
                    logger.LogInformation($"Sublot {sublot.Identifier} moved successfully to {destinationStorageUnit} - Readed from Equipment {reader}");
            }
            catch
            {
                unitOfWork.RollbackTransaction();
                throw;
            }

        }
    }
}
