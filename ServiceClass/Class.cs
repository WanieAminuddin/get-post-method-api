using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Xml.Linq;


namespace ServiceClass
{
    [ServiceContract]
    public interface linkedinServicedata
    {
        [OperationContract]
        void linkedinProfile(string xmlprofile);
    }

    public class linkedinService : linkedinServicedata
    {
        
        public linkedinService() { }
        public void linkedinProfile(string xmlprofile)
        {
            xmlprofile = 
        }
    }
}
