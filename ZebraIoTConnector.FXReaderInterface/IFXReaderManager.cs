using ZebraIoTConnector.DomainModel.Reader;

namespace ZebraIoTConnector.FXReaderInterface
{
    public interface IFXReaderManager
    {
        string GetDefaultConfiguration();
        string GetDefaultOperationMode();
        List<string> GetReaderNames();
        bool IsReaderConfigured(string readerName);
        void SetReaderConfigured(string readerName);
        public void HeartBeatEventReceived(HeartBeatEvent heartBeatEvent);
        public void TagDataEventReceived(string clientId, List<TagReadEvent> tagReadEvent);
    }
}