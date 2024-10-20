using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTProject.Core.Domain
{
    public class Device
    {
        private string Name { get; set; }
        private string Type { get; set; }
        private bool Status { get; set; }

        public Device() { }

        public Device(string name, string type)
        {
            this.Name = name;
            this.Type = type;
            this.Status = false;
        }

        public void UpdateStatus(bool status)
        {   
            this.Status = status;
        }
    }
}
