using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZebraIoTConnector.DomainModel.Dto;

namespace ZebraIoTConnector.Persistence.Repositories
{
    public interface ISublotRepository
    {
        public List<SublotDto> GetSublotByIdentifiers(params string[] identifiers);
        public void MoveSublots(List<SublotDto> sublots, string newStorageUnit);
    }
}
