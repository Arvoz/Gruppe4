using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTProject.Core.Domain
{
    public class Backup
    {
        public string BackupName { get; set; }
        public DateTime CreatedAt { get; set; }
        public GroupDevice GroupDevices { get; set; }

        public Backup(string backupName, DateTime created, GroupDevice group)
        {
            this.BackupName = backupName;
            this.CreatedAt = created;
            this.GroupDevices = group;
        }
    }
}
