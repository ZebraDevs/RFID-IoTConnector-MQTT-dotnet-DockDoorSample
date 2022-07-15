namespace ZebraIoTConnector.FXReaderInterface
{
    public interface IFXReaderManager
    {
        public void HearthBeatEventReceived();
        public void TagDataEventReceived();
        public void GPInStatusChanged();
    }
}