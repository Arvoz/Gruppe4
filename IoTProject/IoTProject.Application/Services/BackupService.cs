using IoTProject.Core.Ports;
using IoTProject.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IoTProject.Application.Services
{
    public class BackupService : IBackupService
    {
        private readonly IBackupRepository _backupRepository;

        public BackupService(IBackupRepository backupRepository)
        {
            _backupRepository = backupRepository;
        }

        public void CreateBackup(GroupDevice group, string backupName)
        {
            var backup = new Backup(backupName, DateTime.Now, group);
            _backupRepository.SaveBackup(backup);
        }

        public Backup RestoreBackup(string backupName)
        {
            return _backupRepository.GetBackupByName(backupName);
        }

    }
}
