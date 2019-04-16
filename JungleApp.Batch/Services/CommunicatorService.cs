using Integra.Communicator.Contract.Common;
using Integra.Communicator.Contract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JungleApp.Batch.Services
{
    public class CommunicatorService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeName">
        /// The assembly-qualified name of the type to get.
        /// typeName can be the type name qualified by its namespace 
        /// or an assembly-qualified name that includes an assembly name 
        /// specification.
        /// If typeName includes the namespace but not the assembly name, 
        /// this method searches only the calling object's assembly and Mscorlib.dll, in that order. 
        /// If typeName is fully qualified with the partial or complete assembly name, 
        /// this method searches in the specified assembly
        /// </param>
        /// <returns></returns>
        public ICommunicator GetCommunicator(string typeName)
        {
            Type communicatorType = Type.GetType(typeName);

            if (communicatorType == null)
                throw new NullReferenceException();

            ICommunicator communicator = Activator.CreateInstance(communicatorType, new object[] { new ConnectionParameters()
            {
                IP = "My IP",
                Port = 993
            } }) as ICommunicator;

            return communicator;
        }

    }
}
