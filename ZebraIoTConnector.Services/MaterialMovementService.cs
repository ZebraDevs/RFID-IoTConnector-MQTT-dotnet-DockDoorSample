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
        private readonly IUnitOfWork unitOfWork;

        public MaterialMovementService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public void NewTagReaded(string clientId, List<TagReadEvent> tagReadEvent)
        {
            // Retrieve equipment by name (clientId).
            var reader = unitOfWork.EquipmentRepository.GetEquipmentByName(clientId);

            // Retrieve sublots associated to readed epcs
            var sublots = unitOfWork.SublotRepository.GetSublotByIdentifiers(tagReadEvent.Select(x => x.IdHex).ToArray());

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
            }
            catch
            {
                unitOfWork.RollbackTransaction();
                throw;
            }

        }
    }
}
