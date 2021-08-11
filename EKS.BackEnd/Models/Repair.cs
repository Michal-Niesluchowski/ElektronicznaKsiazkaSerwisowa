using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKS.BackEnd.Models
{
    public class Repair
    {
        #region fields
        public DateTime Date { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal Cost { get; private set; }
        public string WorkshopName { get; private set; }
        #endregion

        #region contructors
        public Repair(DateTime date, string title, string description, decimal cost, string workshopName)
        {
            this.Date = date;
            this.Title = title;
            this.Description = description;
            this.Cost = cost;
            this.WorkshopName = workshopName;
        }
        #endregion
    }
}
