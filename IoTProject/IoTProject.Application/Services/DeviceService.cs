using IoTProject.Core.Domain;
using IoTProject.Core.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTProject.Application.Services
{
    public class DeviceService
    {

        private readonly IDeviceRepository _deviceRepository;

        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public void AddDevice(Device device)
        {
            _deviceRepository.AddDevice(device);
            _deviceRepository.SaveChanges();
        }

        public void RemoveDevice(string deviceName)
        {
            _deviceRepository.RemoveDevice(deviceName);
            _deviceRepository.SaveChanges();
        }

        public Device GetDeviceByName(string deviceName)
        {
            return _deviceRepository.GetDeviceByName(deviceName);
        }

        public IEnumerable<Device> GetAllDevices()
        {
            return _deviceRepository.GetAllDevices();
        }

    }
}
