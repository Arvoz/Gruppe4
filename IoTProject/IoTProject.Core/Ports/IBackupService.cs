using IoTProject.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTProject.Core.Ports
{
    public interface IBackupService
    {
        void CreateBackup(GroupDevice group, string backupName);
        Backup RestoreBackup(string backupName);
    }
}
