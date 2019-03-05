using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleApp.Services
{
    public class ExceptionService
    {
        public void ThowSomething()
        {
            throw new Exception("BIG EXCEPTION!!!");
        }
    }
}
