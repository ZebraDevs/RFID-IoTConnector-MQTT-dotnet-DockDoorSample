using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZebraIoTConnector.Persistence.Repositories;

namespace ZebraIoTConnector.Persistence
{
    public interface IUnitOfWork
    {
        IEquipmentRepository EquipmentRepository { get; }
        ISublotRepository SublotRepository { get; }
        IInventoryOperationRepository InventoryOperationRepository { get; }

        public void BeginTransaction();
        public void CommitTransaction();
        public void RollbackTransaction();
    }
}
