using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FireboxConfigVisualizer
{
    public class Alias
    {
        public Alias()
        {
            AliasMembers = new List<AliasMember>();
        }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlArray("alias-member-list")]
        [XmlArrayItem("alias-member")]
        public List<AliasMember> AliasMembers { get; set; }

        public override string ToString()
        {
            return Name.Split('.')[0];
        }
    }

    public class AliasMember
    {
        public bool highlight;

        [XmlElement("type")]
        public int Type { get; set; }

        [XmlElement("user")]
        public string User { get; set; }

        [XmlElement("address")]
        public string Address { get; set; }

        [XmlElement("interface")]
        public string Interface { get; set; }

        [XmlElement("alias-name")]
        public string AliasName { get; set; }

        public override string ToString()
        {
            if (Type == 2)
                return AliasName.Split('.')[0];
            else if (Type == 1)
                return Address.Split('.')[0];
            else
                return "All";
        }
    }
}
