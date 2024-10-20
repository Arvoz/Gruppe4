using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTProject.Core.Domain
{
    internal class Group
    {
        public string GroupName { get; set; }
        public List<Device> Devices { get; set; }

        public Group(string groupName, Device device)
        {
            this.GroupName = groupName;
            this.Devices = new List<Device>();
            this.Devices.Add(device);
        }

        public Group(string groupName)
        {
            this.GroupName=groupName;
        }

        public void AddToGroup(Device device)
        {
            if (this.Devices.Contains(device))
            {
                this.Devices.Add(device);
            }
            throw new ArgumentNullException(nameof(device));
        }
    }
}
