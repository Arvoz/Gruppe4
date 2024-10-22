using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTProject.Core.Domain
{
    public class Device
    {
        public string DeviceName { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }

        public Device(string name, string type)
        {
            this.DeviceName = name;
            this.Type = type;
            this.Status = false;
        }

        public Device(string name, string type, bool status)
        {
            this.DeviceName = name;
            this.Type = type;
            this.Status = status;
        }

        public Device()
        {
            
        }

        public void UpdateStatus()
        {
            if (Status)
            {
                Status = false;
            }
            Status = true;
        }

    }
}
