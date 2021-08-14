using EKS.BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKS.FullClient.Framework.TempData
{
    public class TempDataService : ITempDataService
    {
        private Car _newCar;
        private Repair _newRepair;
        
        public void SaveCar(Car newCar) => _newCar = newCar;
        public Car LoadCar() => _newCar;
        public void ClearCar() => _newCar = null;

        public void SaveRepair(Repair newRepair) => _newRepair = newRepair;
        public Repair LoadRepair() => _newRepair;
        public void ClearRepair() => _newRepair = null;
    }
}
