using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;



namespace ServiceClass
{
    [ServiceContract]
    public interface linkedinServicedata
    {
        [OperationContract]
        string linkedinProfile();
    }

    public class linkedinService : linkedinServicedata
    {
        public linkedinService() { }
        public static string Profilexml;

        public void getstring(string data)
        {
            Profilexml = data;
        }

        public string linkedinProfile()
        {
            return Profilexml;
        }
    }
}
