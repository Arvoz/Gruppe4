using IoTProject.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTProject.Core.Ports
{
    public interface IGroupDeviceRepository
    {
        IEnumerable<GroupDevice> GetAllGroupDevices();
        GroupDevice GetGroupDeviceByName(string groupName);
        void SaveGroupDevice(GroupDevice groupDevice);
        void DeleteGroupDevice(string groupName);
    }
}
