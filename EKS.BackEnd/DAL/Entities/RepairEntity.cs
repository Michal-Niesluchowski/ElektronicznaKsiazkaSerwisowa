using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKS.BackEnd.DAL.Entities
{
    public class RepairEntity
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public string WorkshopName { get; set; }
        public Guid Id { get; set; }
    }
}
