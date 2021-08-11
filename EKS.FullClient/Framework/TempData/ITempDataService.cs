using EKS.BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKS.FullClient.Framework.TempData
{
    public interface ITempDataService
    {
        void SaveCar(Car newCar);

        Car LoadCar();

        void SaveTestCar();
    }
}
