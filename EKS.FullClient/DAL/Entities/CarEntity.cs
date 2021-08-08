using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKS.FullClient.DAL.Entities
{
    public class CarEntity
    {
        public string Name { get; set; }
        public string Plate { get; set; }
        public string Description { get; set; }
        public List<RepairEntity> Repairs { get; set; }
    }
}
