using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Linq;

namespace IIProjectService
{
    //har du senaste nu?

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IPassageService
    {

        [OperationContract]
        string GetData(int value);
        [OperationContract]
        XElement GetTestXML();

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        //Testmetoder epcis
        [OperationContract]
        IEnumerable<string> GetFilenames();
        [OperationContract]
        XElement GetEvent(string filename);

        //namingmetoder
        [OperationContract]
        XElement GetVeichle(string epc);
        [OperationContract]
        XElement GetLocation(string epc);
        [OperationContract]
        IEnumerable<XElement> GetAllLocations();

        //[OperationContract]
        //XElement FordonspassageByTime(string time);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
