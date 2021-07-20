using DesktopApplication.BLL;
using DesktopApplication.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApplication.DAL.Repositories
{
    public class RepositoryXML : IRepository
    {
        public bool AddCar(Car car)
        {
            CarEntity newcar = new CarEntity
            {
                CarID = car.CarID,
                Description = car.Description,
                Name = car.Name,
                OwnerTelephone = car.OwnerTelephone,
                Plate = car.Plate,
                Repairs = ConvertToEntity(car.Repairs)
            };

            // Implement save data in XML

            return true;
        }

        //Convert list of repairs to list of repairs entity
        private List<RepairEntity> ConvertToEntity(List<Repair> repairs)
        {
            List<RepairEntity> result = new List<RepairEntity>();
            RepairEntity repairItemDTO = new RepairEntity();

            foreach (Repair repair in repairs)
            {
                result.Add(repairItemDTO.ConvertToEntity(repair));
            }

        return result;
        }
    }
}
