using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZebraIoTConnector.Persistence.Repositories;

namespace ZebraIoTConnector.Persistence
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ZebraDbContext zebraDbContext;
        
        private readonly EquipmentRepository equipmentRepository;
        private readonly SublotRepository sublotRepository;
        private readonly InventoryOperationRepository inventoryOperationRepository;

        public IEquipmentRepository EquipmentRepository => equipmentRepository;
        public ISublotRepository SublotRepository => sublotRepository;
        public IInventoryOperationRepository InventoryOperationRepository => inventoryOperationRepository;

        public UnitOfWork(ZebraDbContext zebraDbContext)
        {
            this.zebraDbContext = zebraDbContext ?? throw new ArgumentNullException(nameof(zebraDbContext));

            equipmentRepository = new EquipmentRepository(zebraDbContext);
            sublotRepository = new SublotRepository(zebraDbContext);
            inventoryOperationRepository = new InventoryOperationRepository(zebraDbContext);
        }

        public void BeginTransaction()
        {
            zebraDbContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            zebraDbContext.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            zebraDbContext.Database.RollbackTransaction();
        }

        public void Dispose()
        {
            zebraDbContext.Dispose();
        }
    }
}
