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
        public bool CreateNewCar(CarEntity car, string saveDestination)
        {
            //Prepare full save path
            string fullSavePath = Path.Combine(saveDestination, car.Name);
            fullSavePath += ".xml";

            //Serialize to XML
            using (TextWriter textWriter = new StreamWriter(fullSavePath))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarEntity));
                xmlSerializer.Serialize(textWriter, car);
            }

            //Finalize
            return true;
        }
    }
}


