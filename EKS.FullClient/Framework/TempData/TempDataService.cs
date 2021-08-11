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

        public void SaveTestCar()
        {
            Car newTestCar = new Car("Renault Clio", "WH 34822");
            newTestCar.AddRepair(new DateTime(2021, 5, 20), "Wymiana oleju", "Olej Castrol 5w30, filtr oleju, płukanka", 
                500, "Marcin Głowice");
            newTestCar.AddRepair(new DateTime(2021, 6, 19), "Naprawa klimatyzacji", "Wymiana sprężarki na regenerowaną", 
                1200, "Magic Mechanik");
            newTestCar.AddRepair(new DateTime(2021, 7, 29), "Pierdolety", "Wymiana paska alternatowa + filtr paliwa", 
                100, "Marcin Głowice");

            this.SaveCar(newTestCar);
        }
    }
}
