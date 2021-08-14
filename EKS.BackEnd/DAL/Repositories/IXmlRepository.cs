using EKS.BackEnd.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKS.BackEnd.DAL.Repositories
{
    public interface IXmlRepository
    {
        bool SaveCar(CarEntity car, string fullFilePath);

        CarEntity LoadCar(string fullFilePath);
    }
}
