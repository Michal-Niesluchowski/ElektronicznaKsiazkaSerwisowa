using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKS.BackEnd.DAL.Entities
{
    public class CarEntity
    {
        public string Name { get; set; }
        public string Plate { get; set; }
        public List<RepairEntity> Repairs { get; set; }

        public override bool Equals(object obj)
        {
            CarEntity other = obj as CarEntity;

            if (other == null)
            {
                return false;
            }

            return this.Name == other.Name &&
                   this.Plate == other.Plate;
        }
    }
}
