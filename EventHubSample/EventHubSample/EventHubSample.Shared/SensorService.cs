using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace EventHubSample
{
    public class SensorService
    {

        public void SendReading(SensorReading currentReading)
        {
            EventHubProxy.SendSBMessage(JsonConvert.SerializeObject(currentReading));
        }
    }
}
