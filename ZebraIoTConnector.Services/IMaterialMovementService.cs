using ZebraIoTConnector.DomainModel.Reader;

namespace ZebraIoTConnector.Services
{
    public interface IMaterialMovementService
    {
        public void NewTagReaded(string clientId, List<TagReadEvent> tagReadEvent);
    }
}