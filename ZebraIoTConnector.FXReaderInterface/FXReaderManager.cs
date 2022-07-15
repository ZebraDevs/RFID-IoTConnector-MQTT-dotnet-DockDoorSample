using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZebraIoTConnector.FXReaderInterface
{
    internal class FXReaderManager : IFXReaderManager
    {
        public void HearthBeatEventReceived()
        {
            // Call eq registry service
            throw new NotImplementedException();
        }

        public void TagDataEventReceived()
        {
            throw new NotImplementedException();
        }
        public void GPInStatusChanged()
        {
            // Send start reading command

            throw new NotImplementedException();
        }

    }
}
