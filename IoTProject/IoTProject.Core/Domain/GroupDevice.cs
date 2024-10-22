using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTProject.Core.Domain
{
    public class GroupDevice
    {
        public string GroupName { get; set; }
        public List<Device> Devices { get; set; }

        public GroupDevice(string groupName)
        {
            GroupName = groupName;
            Devices = new List<Device>();
        }

        public GroupDevice()
        {
            Devices = new List<Device>();
        }

        public void AddDevice(Device device)
        {
            Devices.Add(device);
        }

        public void RemoveDevice(Device device)
        {
            Devices.Remove(device);
        }
    }
}
