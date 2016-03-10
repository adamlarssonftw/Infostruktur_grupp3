using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Linq;
using System.Web.Hosting;
using IIProjectService.EventAndNamingServiceReference;

namespace IIProjectService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class PassageService : IPassageService
    {
        EpcisEventServiceClient epcisEvent = new EpcisEventServiceClient();
        NamingServiceClient namingEvent = new NamingServiceClient();

        string appdatafolder = HostingEnvironment.MapPath("/App_Data/TestXML.xml");
        
        XElement xmlData;

        public PassageService()
        {
            xmlData = XElement.Load(appdatafolder);
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public XElement GetTestXML()
        {
            return xmlData;
        }



        //epcis-metoder
        public IEnumerable<string> GetFilenames()
        {
            return epcisEvent.GetFilenames();
        }

        public XElement GetEvent(string filename)
        {
            return epcisEvent.GetEvent(filename);
        }

        //naming-metoder
        public XElement GetVeichle(string epc)
        {
            return namingEvent.GetVehicle(epc);
        }

        public XElement GetLocation(string epc)
        {
            return namingEvent.GetLocation(epc);
        }

        public IEnumerable<XElement> GetAllLocations()
        {
            IEnumerable<XElement> lista = namingEvent.GetAllLocations().Elements("Locations").Select(x => x.Element("Name"));
            return lista;
        }
    }
}
