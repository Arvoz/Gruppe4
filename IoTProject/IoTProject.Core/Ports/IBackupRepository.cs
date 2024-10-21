using IoTProject.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTProject.Core.Ports
{
    public interface IBackupRepository
    {
        void SaveBackup(Backup backup);
        Backup GetBackupByName(string backupName);
    }
}
