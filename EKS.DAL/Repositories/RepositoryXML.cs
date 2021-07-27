using DesktopApplication.DAL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DesktopApplication.DAL.Repositories
{
    public class RepositoryXML
    {
        public bool CreateNewCar(string plate, string name, string description, string saveDestination)
        {
            //Create car entity
            CarEntity newCar = new CarEntity
            {
                Name = name,
                Plate = plate,
                Description = description,
                Repairs = new List<RepairEntity>()
            };

            //Prepare full save path
            string fullSavePath = Path.Combine(saveDestination, name);
            fullSavePath += ".xml";

            //Serialize to XML
            using (TextWriter textWriter = new StreamWriter(fullSavePath))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarEntity));
                xmlSerializer.Serialize(textWriter, newCar);
            }

            //Finalize
            return true;
        }
    }
}


