using EKS.BackEnd.DAL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EKS.BackEnd.DAL.Repositories
{
    public class XmlRepository : IXmlRepository
    {
        public bool SaveCar(CarEntity car, string fullFilePath)
        {
            try
            {
                using (TextWriter textWriter = new StreamWriter(fullFilePath))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarEntity));
                    xmlSerializer.Serialize(textWriter, car);
                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public CarEntity LoadCar(string fullFilePath)
        {
            try
            {
                CarEntity result;

                using (FileStream fileStream = new FileStream(fullFilePath, FileMode.Open))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarEntity));
                    result = (CarEntity)xmlSerializer.Deserialize(fileStream);
                }

                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}


