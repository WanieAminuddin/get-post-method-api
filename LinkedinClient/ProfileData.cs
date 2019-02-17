using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;


namespace LinkedInOauth.Models
{
    public class person
    {
        [XmlElement("first-name")]
        public string FName;

        [XmlElement("last-name")]
        public string LName;
      
        [XmlElement("picture-url")]
        public string imageurl;
       
        [XmlElement("num-connections")]
        public int connections;

        [XmlElement("name")]
        public string place;

        public string headline;
        public string summary;

        [XmlElement("location")]
        public location location;

    }
    public class location
    {
        public string name;
    }

}

