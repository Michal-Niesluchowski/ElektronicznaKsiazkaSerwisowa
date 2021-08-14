using EKS.BackEnd.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EKS.BackEnd.Models
{
    public class Car
    {
        #region fields/properties
        private string _name;
        private string _plate;
        private ObservableCollection<Repair> _repairs;
        #endregion

        #region constructors
        public Car(string name, string plate)
        {
            this.Name = name;
            this.Plate = plate;
            this.Repairs = new ObservableCollection<Repair>();
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
        public ObservableCollection<Repair> Repairs
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
        public void EditCar(string carName, string carPlate)
        {
            this.Name = carName;
            this.Plate = carPlate;
        }
        
        public void AddRepair(Repair repair)
        {
            this.Repairs.Add(repair);
        }

        public void DeleteRepair(Guid repairId)
        {
            Repair repair = this.Repairs.Where(r => r.Id == repairId).FirstOrDefault();

            this.Repairs.Remove(repair);
        }

        public CarEntity ToEntity()
        {
            CarEntity result = new CarEntity
            {
                Name = this.Name,
                Plate = this.Plate,
                Repairs = new List<RepairEntity>()
            };

            foreach (Repair repair in Repairs)
            {
                result.Repairs.Add(repair.ToEntity());
            }

            return result;
        }

        public static Car FromEntity(CarEntity carEntity)
        {
            Car result = new Car(carEntity.Name, carEntity.Plate);

            foreach (RepairEntity repairEntity in carEntity.Repairs)
            {
                result.AddRepair(Repair.FromEntity(repairEntity));
            }

            return result;
        }

        public override string ToString()
        {
            return Name + Plate;
        }

        public override bool Equals(object obj)
        {
            Car other = obj as Car;

            if (other == null) return false;

            if (this.Name != other.Name) return false;

            if (this.Plate != other.Plate) return false;

            for (int i = 0; i < this.Repairs.Count; i++)
            {
                if (! this.Repairs[0].Equals(other.Repairs[0]))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
