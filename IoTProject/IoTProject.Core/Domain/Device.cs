using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTProject.Core.Domain
{
    public class Device
    {
        public string DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }

        public Device() { }

        public Device(string id, string name, string type)
        {
            this.DeviceId = id;
            this.DeviceName = name;
            this.Type = type;
            this.Status = false;
        }

        public void UpdateStatus(bool status)
        {   
            this.Status = status;
        }
    }
}
