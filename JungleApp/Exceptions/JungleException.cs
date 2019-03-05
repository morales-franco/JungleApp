using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace JungleApp.Exceptions
{
    [Serializable]
    public class JungleException: Exception, ISerializable
    {
        public JungleException()
        {

        }

        public JungleException(string message) : base(message)
        {

        }

        public JungleException(string message, Exception ex) : base(message, ex)
        {

        }



    }
}
