﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKS.BackEnd.Models
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

        public override string ToString()
        {
            return Name + Plate + Description;
        }

        public override bool Equals(object obj)
        {
            Car other = obj as Car;  
            
            if (other == null)
            {
                return false;
            }

            return this.Name == other.Name &&
                   this.Plate == other.Plate &&
                   this.Description == other.Description;
        }
    }
}