using System;
using System.Runtime.InteropServices;

namespace SPIClient
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class DeviceAddressChangedEventArgs : EventArgs
    {
        public string DeviceAddress { get; set; }

        public DeviceAddressChangedEventArgs() { }
    }
}
