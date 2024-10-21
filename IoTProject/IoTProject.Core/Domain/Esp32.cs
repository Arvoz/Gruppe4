using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTProject.Core.Domain
{
    public class Esp32
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public Esp32(string id, string name, string status)
        {
            this.Id = id;
            this.Name = name;
            this.Status = status;
        }

    }
}
