using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JungleApp.Models
{
    [Serializable]
    [XmlRoot("Provider")]
    public class Provider
    {
        [XmlAttribute("ID")]
        public int ProviderId { get; set; }

        public string CompletedName { get; set; }

        [XmlElement("Years")]
        public int Age { get; set; }

        public DateTime Birth { get; set; }

        [XmlElement("MyStuffs")]
        public List<string> Stuffs { get; set; }

        [XmlIgnore]
        public string AccessKey { get; set; }


    }
}
