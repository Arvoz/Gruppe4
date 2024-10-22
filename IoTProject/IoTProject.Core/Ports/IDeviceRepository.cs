using IoTProject.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTProject.Core.Ports
{
    public interface IDeviceRepository
    {

        void AddDevice(Device device);
        void RemoveDevice(string deviceName);
        Device GetDeviceByName(string deviceName);
        IEnumerable<Device> GetAllDevices();
        void SaveChanges();

    }
}
