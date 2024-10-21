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
    public class FileStorageGroupDeviceRepository : IGroupDeviceRepository
    {
        private readonly string groupDirectory = "groups";

        public FileStorageGroupDeviceRepository()
        {
            if (!Directory.Exists(groupDirectory))
            {
                Directory.CreateDirectory(groupDirectory);
            }
        }

        public IEnumerable<GroupDevice> GetAllGroupDevices()
        {
            var groupDevices = new List<GroupDevice>();
            foreach (var file in Directory.GetFiles(groupDirectory, "*.json"))
            {
                string jsonData = File.ReadAllText(file);
                groupDevices.Add(JsonSerializer.Deserialize<GroupDevice>(jsonData));
            }
            return groupDevices;
        }

        // Hent en gruppe basert på gruppenavn
        public GroupDevice GetGroupDeviceByName(string groupName)
        {
            string filePath = Path.Combine(groupDirectory, $"{groupName}.json");
            if (!File.Exists(filePath))
            {
                return null; // Returner null hvis gruppen ikke finnes
            }

            string jsonData = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<GroupDevice>(jsonData);
        }

        // Lagre eller oppdatere en gruppe
        public void SaveGroupDevice(GroupDevice groupDevice)
        {
            string filePath = Path.Combine(groupDirectory, $"{groupDevice.GroupName}.json");
            string jsonData = JsonSerializer.Serialize(groupDevice, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonData);
        }

        // Slett en gruppe basert på gruppenavn
        public void DeleteGroupDevice(string groupName)
        {
            string filePath = Path.Combine(groupDirectory, $"{groupName}.json");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
