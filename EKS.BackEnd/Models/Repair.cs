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
        public DateTime _date { get; private set; }
        public string _title { get; private set; }
        public string _description { get; private set; }
        public decimal _cost { get; private set; }
        public string _workshopName { get; private set; }
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
        public string Title
        {
            get
            {
                return _title;
            }
            private set
            {
                _title = value;
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
        #endregion
    }
}
