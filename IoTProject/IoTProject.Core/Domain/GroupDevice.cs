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

        public GroupDevice(string groupName, Device device)
        {
            this.GroupName = groupName;
            this.Devices = new List<Device>();
        }

        public void AddDevice(Device device)
        {
            if (this.Devices.Contains(device))
            {
                this.Devices.Add(device);
            }
            throw new ArgumentNullException(nameof(device));
        }

        public GroupDevice()
        {
            
        }

        public void RemoveDevice(Device device)
        {
            if (!this.Devices.Contains(device))
            {
                throw new ArgumentNullException(nameof(device));
            }
            this.Devices.Remove(device);
        }
    }
}
