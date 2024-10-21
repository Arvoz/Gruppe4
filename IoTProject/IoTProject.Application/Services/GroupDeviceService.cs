using IoTProject.Core.Domain;
using IoTProject.Core.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTProject.Application.Services
{
    public class GroupDeviceService : IGroupDeviceService
    {
        private readonly IGroupDeviceRepository _groupDeviceRepo;

        public GroupDeviceService(IGroupDeviceRepository groupDeviceRepository)
        {
            _groupDeviceRepo = groupDeviceRepository;
        }

        public IEnumerable<GroupDevice> GetAllGroups()
        {
            return _groupDeviceRepo.GetAllGroupDevices();
        }

        public GroupDevice GetGroupDeviceByName(string groupName)
        {
            return _groupDeviceRepo.GetGroupDeviceByName(groupName);
        }

        public void CreateOrUpdateGroup(GroupDevice groupDevice)
        {
            _groupDeviceRepo.SaveGroupDevice(groupDevice);
        }

        public void DeleteGroup(string groupName)
        {
            _groupDeviceRepo.DeleteGroupDevice(groupName);
        }

    }
}
