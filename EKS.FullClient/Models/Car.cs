using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApplication.BLL
{
    public class Car
    {
        public string Name { get; private set; }
        public string Plate { get; private set; }
        public string Description { get; private set; }
        public List<Repair> Repairs { get; private set; }

        public Car(string name, string plate, string description)
        {
            this.Name = name;
            this.Plate = plate;
            this.Description = description;
            this.Repairs = new List<Repair>();
        }
    }
}
