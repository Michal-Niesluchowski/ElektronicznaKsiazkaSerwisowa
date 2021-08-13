using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKS.BackEnd.Models
{
    public class Repair
    {
        #region fields
        private DateTime _date;
        private string _description;
        private decimal _cost;
        private string _workshopName;
        private Guid _id;
        #endregion

        #region contructors
        public Repair(DateTime date, string description, decimal cost, string workshopName)
        {
            this.Date = date;
            this.Description = description;
            this.Cost = cost;
            this.WorkshopName = workshopName;
            this.Id = Guid.NewGuid();
        }
        #endregion

        #region properties
        public DateTime Date 
        {
            get
            {
                return _date;
            }
            private set
            {
                _date = value;
            }
        }
        public string Description 
        {
            get
            {
                return _description;
            }
            private set
            {
                _description = value;
            }
        }
        public decimal Cost
        {
            get
            {
                return _cost;
            }
            private set
            {
                _cost = value;
            }
        }
        public string WorkshopName
        {
            get
            {
                return _workshopName;
            }
            private set
            {
                _workshopName = value;
            }
        }
        public Guid Id
        {
            get
            {
                return _id;
            }
            private set
            {
                _id = value;
            }
        }
        #endregion

        #region methods
        public override bool Equals(object obj)
        {
            Repair other = obj as Repair;

            if (other == null)
            {
                return false;
            }

            return this.Cost == other.Cost &&
                   this.Date == other.Date &&
                   this.Description == other.Description &&
                   this.WorkshopName == other.WorkshopName;
        }
        #endregion
    }
}
