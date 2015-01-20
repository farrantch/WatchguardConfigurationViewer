using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FireboxConfigVisualizer
{
    public class Policy
    {
        public Policy()
        {

        }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("service")]
        public string Service { get; set; }

        [XmlElement("firewall")]
        public int Firewall { get; set; }

        [XmlArray("from-alias-list")]
        [XmlArrayItem("alias")]
        public List<string> FromAliases { get; set; }

        [XmlArray("to-alias-list")]
        [XmlArrayItem("alias")]
        public List<string> ToAliases { get; set; }

        [XmlElement("enable")]
        public int enable { get; set; }

        public string GetName()
        {
            string[] split = Name.Split('-');
            return split[0];
        }
    }


}


