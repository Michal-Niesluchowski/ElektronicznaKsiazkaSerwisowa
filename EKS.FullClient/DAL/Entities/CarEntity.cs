using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApplication.DAL.Entities
{
    public class CarEntity
    {
        public string Name { get; set; }
        public string Plate { get; set; }
        public string Description { get; set; }
        public List<RepairEntity> Repairs { get; set; }
    }
}
