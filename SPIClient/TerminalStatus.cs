using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPIClient
{
    public class TerminalStatusRequest
    {
        public TerminalStatusRequest() { }

        public Message ToMessage()
        {
            var data = new JObject();

            return new Message(RequestIdHelper.Id("trmnl"), Events.TerminalStatusRequest, data, true);
        }
    }

    public class TerminalStatusResponse
    {
        private Message _m;

        public TerminalStatusResponse(Message m)
        {
            _m = m;
        }
        public string GetStatus()
        {
            return _m.GetDataStringValue("status");
        }
        public string GetBatteryLevel()
        {
            return _m.GetDataStringValue("battery_level");
        }
        public bool IsCharging()
        {
            return _m.GetDataBoolValue("charging", false);
        }
    }

    public class TerminalBattery
    {
        public string BatteryLevel { get; }

        public TerminalBattery(Message m)
        {
            BatteryLevel = m.GetDataStringValue("battery_level");
        }
    }
}
