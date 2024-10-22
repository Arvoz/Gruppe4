using IoTProject.Core.Domain;
using IoTProject.Core.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IoTProject.Infrastructure.FileStorage
{
    public class FileStorageDeviceRepository : IDeviceRepository
    {

        private const string _filePath = "device.json";
        private List<Device> _devices;

        public FileStorageDeviceRepository()
        {
            if (!File.Exists(_filePath))
            {
                InitializeEmptyFile();
            }
            _devices = LoadDevicesFromFile();
        }

        public void AddDevice(Device device)
        {
            _devices.Add(device);
        }

        public void RemoveDevice(string deviceName)
        {
            var device = _devices.Find(d => d.DeviceName == deviceName);
            if (device != null)
            {
                _devices.Remove(device);
            }
        }

        public Device GetDeviceByName(string deviceName)
        {
            return _devices.Find(d => d.DeviceName == deviceName);
        }

        public IEnumerable<Device> GetAllDevices()
        {
            return _devices;
        }

        public void SaveChanges()
        {
            var jsonData = JsonSerializer.Serialize(_devices, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, jsonData);
        }

        private List<Device> LoadDevicesFromFile()
        {
            var jsonData = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Device>>(jsonData) ?? new List<Device>();

        }

        private void InitializeEmptyFile()
        {
            var emptyDevices = new List<Device>();
            var jsonData = JsonSerializer.Serialize(emptyDevices, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, jsonData);

        }
    }
}
