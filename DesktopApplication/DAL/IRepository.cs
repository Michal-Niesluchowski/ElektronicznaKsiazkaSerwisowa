using DesktopApplication.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApplication.DAL
{
    public interface IRepository
    {
        Car AddCar(Car car);
    }
}
