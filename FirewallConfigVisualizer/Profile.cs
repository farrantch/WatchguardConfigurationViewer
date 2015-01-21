using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FireboxConfigVisualizer
{
    [XmlType("profile")]
    public class Profile
    {
        public Profile()
        {
            Policies = new List<Policy>();
            Services = new List<Service>();
            AbsPolicies = new List<AbsPolicy>();
            Aliases = new List<Alias>();
            Addresses = new List<Address>();
            Nats = new List<Nat>();
        }

        [XmlArray("policy-list")]
        [XmlArrayItem("policy")]
        public List<Policy> Policies { get; set; }

        [XmlArray("service-list")]
        [XmlArrayItem("service")]
        public List<Service> Services { get; set; }

        [XmlArray("alias-list")]
        [XmlArrayItem("alias")]
        public List<Alias> Aliases { get; set; }

        [XmlArray("address-group-list")]
        [XmlArrayItem("address-group")]
        public List<Address> Addresses { get; set; }

        [XmlArray("abs-policy-list")]
        [XmlArrayItem("abs-policy")]
        public List<AbsPolicy> AbsPolicies { get; set; }

        [XmlArray("nat-list")]
        [XmlArrayItem("nat")]
        public List<Nat> Nats { get; set; }
    }
}
