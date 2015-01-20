using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FireboxConfigVisualizer
{
    public class Service
    {
        public Service()
        {
            ServiceMembers = new List<ServiceMember>();
        }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("property")]
        public int Property { get; set; }

        [XmlArray("service-item")]
        [XmlArrayItem("member")]
        public List<ServiceMember> ServiceMembers { get; set; }

    }

    [XmlType("member")]
    public class ServiceMember
    {
        [XmlElement("type")]
        public string Type { get; set; }

        [XmlElement("protocol")]
        public string Protocol { get; set; }

        [XmlElement("server-port")]
        public string ServerPort { get; set; }

        [XmlElement("start-server-port")]
        public string StartServerPort { get; set; }

        [XmlElement("end-server-port")]
        public string EndServerPort { get; set; }

        [XmlElement("icmp-type")]
        public string ICMPType { get; set; }

        [XmlElement("icmp-code")]
        public string ICMPCode { get; set; }

        public string GetServerPort()
        {
            //Single
            if (Type == "1")
            {
                // ICMP
                if (String.IsNullOrEmpty(ServerPort))
                {
                    return "Ping";
                }
                else
                {
                    if (ServerPort == "0")
                        return "Any";
                    else
                        return ServerPort;
                }
            }
            //Range
            else if (Type == "2")
                return StartServerPort + " - " + EndServerPort;
            else
                return "";
        }

        public string GetProtocol()
        {
            if (Protocol == "0")
                return "Any";
            else if (Protocol == "6")
                return "TCP";
            else if (Protocol == "17")
                return "UDP";
            else if (Protocol == "1")
                return "ICMP";
            else
                return this.Type;
        }

    }
}
