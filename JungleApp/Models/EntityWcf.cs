using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace JungleApp.Models
{
    [DataContract(Name ="ENTITY-NAME", Namespace ="ENTITY-NAMESPACE")]
    public class EntityWcf
    {

        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [IgnoreDataMember]
        public int Age { get; set; }
    }
}
