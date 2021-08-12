using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKS.BackEnd.Models
{
    public class Car
    {
        #region fields/properties
        private string _name;
        private string _plate;
        private List<Repair> _repairs;
        #endregion

        #region constructors
        public Car(string name, string plate)
        {
            this.Name = name;
            this.Plate = plate;
            this.Repairs = new List<Repair>();
        }
        #endregion

        #region 
        public string Name 
        {
            get 
            {
                return _name;
            }
            private set
            {
                _name = value;
            }
        }
        public string Plate 
        {
            get 
            {
                return _plate;
            }
            private set
            {
                _plate = value;
            }
        }
        public List<Repair> Repairs
        {
            get
            {
                return _repairs;
            }
            private set
            {
                _repairs = value;
            }
        }
        #endregion

        #region methods
        public void AddRepair(Repair repair)
        {
            this.Repairs.Add(repair);
        }

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
