using IoTProject.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTProject.Core.Ports
{
    public interface IGroupDeviceService
    {
        IEnumerable<GroupDevice> GetAllGroups();
        GroupDevice GetGroupDeviceByName(string groupName);
        void CreateOrUpdateGroup(GroupDevice groupDevice);
        void DeleteGroup(string groupName);
    }
}
