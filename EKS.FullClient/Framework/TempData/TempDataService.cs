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
        
        public void SaveCar(Car newCar) => _newCar = newCar;

        public Car LoadCar() => _newCar;
    }
}
