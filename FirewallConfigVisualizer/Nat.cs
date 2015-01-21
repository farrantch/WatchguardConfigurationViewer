using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Net;

namespace FireboxConfigVisualizer
{
    public class Nat
    {
        public Nat()
        {
            NatMembers = new List<NatMember>();
        }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("property")]
        public int Property { get; set; }

        [XmlElement("type")]
        public int Type { get; set; }

        [XmlArray("nat-item")]
        [XmlArrayItem("member")]
        public List<NatMember> NatMembers { get; set; }
    }

    public class NatMember
    {
        [XmlElement("addr-type")]
        public int AddressType { get; set; }

        [XmlElement("port")]
        public int Port { get; set; }

        [XmlElement("ext-addr-name")]
        public string ExternalAddressName { get; set; }

        [XmlElement("interface")]
        public string Interface { get; set; }

        [XmlElement("addr-name")]
        public string AddressName { get; set; }
    }
}
