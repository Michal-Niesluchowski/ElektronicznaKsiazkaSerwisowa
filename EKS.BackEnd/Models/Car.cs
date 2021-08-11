using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKS.BackEnd.Models
{
    public class Car
    {
        #region fields
        public string Name { get; private set; }
        public string Plate { get; private set; }
        public List<Repair> Repairs { get; private set; }
        #endregion

        #region constructors
        public Car(string name, string plate)
        {
            this.Name = name;
            this.Plate = plate;
            this.Repairs = new List<Repair>();
        }
        #endregion

        #region methods
        public void AddRepair(DateTime date, string title, string description, decimal cost, string workshopName)
        {
            Repair newRepair = new Repair(date, title, description, cost, workshopName);
            this.Repairs.Add(newRepair);
        }

        public string WorkshopName { get; private set; }

        public override string ToString()
        {
            return Name + Plate;
        }

        public override bool Equals(object obj)
        {
            Car other = obj as Car;  
            
            if (other == null)
            {
                return false;
            }

            return this.Name == other.Name &&
                   this.Plate == other.Plate;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
