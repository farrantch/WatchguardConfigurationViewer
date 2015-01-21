using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Net;
using FireboxConfigVisualizer;

namespace FireboxConfigVisualizer
{
    public class Address
    {
        public Address()
        {
            AddressMembers = new List<AddressMember>();
        }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("property")]
        public int Property { get; set; }

        [XmlArray("addr-group-member")]
        [XmlArrayItem("member")]
        public List<AddressMember> AddressMembers { get; set; }
    }

    public class AddressMember
    {
        public bool highlight;

        [XmlElement("type")]
        public int Type { get; set; }

        [XmlElement("host-ip-addr")]
        public string HostIPAddress { get; set; }

        [XmlElement("ip-network-addr")]
        public string IPNetworkAddress { get; set; }

        [XmlElement("ip-mask")]
        public string NetMask { get; set; }

        [XmlElement("start-ip-addr")]
        public string StartIPAddress { get; set; }

        [XmlElement("end-ip-addr")]
        public string EndIPAddress { get; set; }

        public override string ToString()
        {
            if (Type == 1)
            {
                if (HostIPAddress == "0.0.0.0")
                    return "Any";
                else
                    return HostIPAddress;
            }
            else if (Type == 2)
            {
                if (IPNetworkAddress == "0.0.0.0" || NetMask == "0.0.0.0")
                    return "Any";
                else
                    return IPNetworkAddress + " /" + GetCIDR(NetMask);
            }
            else if (Type == 3)
                return StartIPAddress + " - " + EndIPAddress;
            else if (Type == 4)
                return StartIPAddress + " -- NAT --> " + EndIPAddress;
            else
                return "";
        }

        private int GetCIDR(string decim)
        {
            int cidr = 0;
            string[] proof = decim.Split('.');

            foreach (string oct in proof)
            {
                int noct;
                if (!Int32.TryParse(oct, out noct) || noct > 255 || noct < 0)
                {
                    throw new Exception(oct + " is not a valid octet.");
                }

                if (noct == 255)
                {
                    cidr += 8;
                }
                else
                {

                    int temp = 0;
                    for (int a = 7; temp != noct; a--, cidr++)
                    {
                        temp += (int)Math.Pow(2, a);
                    }
                }
            }

            return cidr;

        }
    }
}
