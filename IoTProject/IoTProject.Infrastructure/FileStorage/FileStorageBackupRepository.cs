using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using IoTProject.Core.Domain;
using IoTProject.Core.Ports;

namespace IoTProject.Infrastructure.FileStorage
{
    public class FileStorageBackupRepository : IBackupRepository
    {
        private readonly string _backupPath = "backups";

        public FileStorageBackupRepository()
        {
            if (!Directory.Exists(_backupPath))
            {
                Directory.CreateDirectory(_backupPath);
            }
        }

        public void SaveBackup(Backup backup)
        {
            string filePath = Path.Combine(_backupPath, $"{backup.BackupName}.json");
            string jsonData = JsonSerializer.Serialize(backup, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonData);
        }

        public Backup GetBackupByName(string backupName)
        {
            string filePath = Path.Combine(_backupPath, $"{backupName}.json");
            if (!File.Exists(filePath))
            {
                return null;
            }

            string jsonData = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Backup>(jsonData);
        }

    }
}
