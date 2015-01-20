using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FireboxConfigVisualizer
{
    public class AbsPolicy
    {
        public AbsPolicy()
        {

        }

        public int PolicyNumber;

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("property")]
        public int Property { get; set; }

        [XmlElement("service")]
        public string Service { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("enabled")]
        public string Enabled { get; set; }

        [XmlElement("firewall")]
        public string Firewall { get; set; }

        [XmlArray("from-alias-list")]
        [XmlArrayItem("alias")]
        public List<string> FromAlias { get; set; }

        [XmlArray("to-alias-list")]
        [XmlArrayItem("alias")]
        public List<string> ToAlias { get; set; }

        [XmlElement("policy-nat")]
        public string PolicyNat { get; set; }

        [XmlArray("policy-list")]
        [XmlArrayItem("policy")]
        public List<string> PolicyList { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
