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

        public IEquipmentRepository EquipmentRepository => equipmentRepository;
        public ISublotRepository SublotRepository => sublotRepository;

        public UnitOfWork(ZebraDbContext zebraDbContext)
        {
            this.zebraDbContext = zebraDbContext ?? throw new ArgumentNullException(nameof(zebraDbContext));
            equipmentRepository = new EquipmentRepository(zebraDbContext);
            sublotRepository = new SublotRepository(zebraDbContext);
        }


        public void Dispose()
        {
            zebraDbContext.Dispose();
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
    }
}
